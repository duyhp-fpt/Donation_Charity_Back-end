using Donation.Data.Configurations;
using Donation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Data.EF
{
    public class DonationDbContext : DbContext
    {
        public DonationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AdminConfiguration());

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Organization> Organizations { get; set; }

    }
}
