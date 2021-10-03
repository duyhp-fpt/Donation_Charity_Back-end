using Donation.Business.Authentication;
using Donation.Business.Campaign;
using Donation.Business.DonationCase;
using Donation.Business.Fanpage;
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

            services.AddCors();

            services.AddDbContext<DonationContext>(options =>
        options.UseSqlServer("Data Source=40.121.243.60;Initial Catalog=Donation;User ID=sa;Password=123456"));

            services.AddTransient<IUserService, Business.Organizations.UserService>();
            services.AddTransient<ICampaignService, CampaignService>();
            services.AddTransient<IFanpageService, FanpageService>();
            services.AddTransient<IDonationCaseService, DonationCaseService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IPaymentEvidenceService, PaymentEvidenceService>();
            services.AddTransient<IRecordActionService, RecordActionService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddControllers();
            services.AddSwaggerGen();
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

            app.UseRouting();

            app.UseAuthentication();
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
