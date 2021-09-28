using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Donation.Data.EF
{
    public class DonationDbContextFactory : IDesignTimeDbContextFactory<DonationDbContext>
    {
        public DonationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DonationDb");

            var optionsBuilder = new DbContextOptionsBuilder<DonationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DonationDbContext(optionsBuilder.Options);
        }
    }
}
