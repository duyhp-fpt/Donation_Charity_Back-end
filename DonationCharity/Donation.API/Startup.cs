using CorePush.Apple;
using CorePush.Google;
using Donation.API.Models;
using Donation.Business.Authentication;
using Donation.Business.Campaign;
using Donation.Business.DonationCase;
using Donation.Business.Fanpage;
using Donation.Business.Image;
using Donation.Business.Organizations;
using Donation.Business.Payment;
using Donation.Business.PaymentEvidence;
using Donation.Business.Product;
using Donation.Business.RecordAction;
using Donation.Business.Transaction;
using Donation.Data.EF;
using Donation.Data.Entities;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddFireBase();
            services.AddCors();

            services.AddDbContext<DonationContext>(options =>
        options.UseSqlServer("Data Source=TANDAT\\SQLEXPRESS;Initial Catalog=Donation;User ID=sa;Password=dat123"));

            services.AddTransient<IUserService, Business.Organizations.UserService>();
            services.AddTransient<ICampaignService, CampaignService>();
            services.AddTransient<IFanpageService, FanpageService>();
            services.AddTransient<IDonationCaseService, DonationCaseService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IPaymentEvidenceService, PaymentEvidenceService>();
            services.AddTransient<IRecordActionService, RecordActionService>();
            services.AddTransient<IStorageService, FileStorageService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddTransient<INotificationService, NotificationService>();
            services.AddHttpClient<FcmSender>();
            services.AddHttpClient<ApnSender>();

            // Configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("FcmNotification");
            services.Configure<FcmNotificationSetting>(appSettingsSection);

            //api version
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger eShop Solution", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });

            string signingKey = "das789dc677k70ovhh3eikkcbmz7wjvcbsufjj98";
            var signingKeyBytes = Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }

        public virtual FirebaseApp AddFireBase()
        {
            //get current Path
            var currentDirectory = Directory.GetCurrentDirectory();

            //path of firebase json
            var jsonFirebasePath = Path.Combine(currentDirectory, "Cert", "firebase.json");
            //initialize the default app
            var defaulApp = FirebaseApp.Create(new AppOptions
            {
                Credential =  GoogleCredential.FromFile(jsonFirebasePath)
            });

            return defaulApp;
        }
    }
}
