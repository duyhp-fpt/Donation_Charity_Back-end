using Donation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Donation.Data.EF
{
    public class DonationDbContextFactory : IDesignTimeDbContextFactory<DonationContext>
    {
        public DonationContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DonationDb");

            var optionsBuilder = new DbContextOptionsBuilder<DonationContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DonationContext(optionsBuilder.Options);
        }
    }
}
