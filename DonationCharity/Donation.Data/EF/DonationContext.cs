using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class DonationContext : DbContext
    {
        public DonationContext()
        {
        }

        public DonationContext(DbContextOptions<DonationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<DonationCase> DonationCases { get; set; }
        public virtual DbSet<Donator> Donators { get; set; }
        public virtual DbSet<Fanpage> Fanpages { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentEvidence> PaymentEvidences { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RecordAction> RecordActions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.HasOne(d => d.DonationCase)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.DonationCaseId)
                    .HasConstraintName("FK__Campaign__Donati__47DBAE45");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK__Campaign__Organi__46E78A0C");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Campaign__Paymen__48CFD27E");
            });

            modelBuilder.Entity<DonationCase>(entity =>
            {
                entity.ToTable("DonationCase");
            });

            modelBuilder.Entity<Donator>(entity =>
            {
                entity.ToTable("Donator");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.DonatorName).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fanpage>(entity =>
            {
                entity.ToTable("Fanpage");

                entity.Property(e => e.Link).HasMaxLength(100);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Fanpages)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_Fanpage_Organization");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.OrganizationName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.HasOne(d => d.PaymentEvidence)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentEvidenceId)
                    .HasConstraintName("FK__Payment__Payment__412EB0B6");
            });

            modelBuilder.Entity<PaymentEvidence>(entity =>
            {
                entity.ToTable("PaymentEvidence");

                entity.Property(e => e.PaymentEvidenceDate).HasColumnType("date");

                entity.Property(e => e.PaymentEvidenceImage).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Product__Payment__440B1D61");
            });

            modelBuilder.Entity<RecordAction>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("PK__RecordAc__FBDF78E94BB1B9CF");

                entity.ToTable("RecordAction");

                entity.Property(e => e.Action).HasMaxLength(100);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.RecordActions)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK__RecordAct__Admin__52593CB8");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.RecordActions)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK__RecordAct__Organ__5165187F");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.DonateDate).HasColumnType("date");

                entity.Property(e => e.DonatorCardNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK__Transacti__Campa__4CA06362");

                entity.HasOne(d => d.Donator)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.DonatorId)
                    .HasConstraintName("FK__Transacti__Donat__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
