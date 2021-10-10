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

        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<DonationCase> DonationCases { get; set; }
        public virtual DbSet<Fanpage> Fanpages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentEvidence> PaymentEvidences { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RecordAction> RecordActions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValue(true);

                entity.HasOne(d => d.DonationCase)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.DonationCaseId)
                    .HasConstraintName("FK__Campaign__Donati__47DBAE45");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_Campaign_User");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Campaign__Paymen__48CFD27E");
            });

            modelBuilder.Entity<DonationCase>(entity =>
            {
                entity.ToTable("DonationCase");

                entity.Property(e => e.Status).HasDefaultValue(true);
            });

            modelBuilder.Entity<Fanpage>(entity =>
            {
                entity.ToTable("Fanpage");

                entity.Property(e => e.Link).HasMaxLength(100);

                entity.Property(e => e.Status).HasDefaultValue(true);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Fanpages)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_Fanpage_User");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.Status).HasDefaultValue(true);
            });

            modelBuilder.Entity<PaymentEvidence>(entity =>
            {
                entity.ToTable("PaymentEvidence");

                entity.Property(e => e.PaymentEvidenceDate).HasColumnType("date");

                entity.Property(e => e.PaymentEvidenceImage).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValue(true);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PaymentEvidences)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PaymentEvidence_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.Status).HasDefaultValue(true);

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

                entity.Property(e => e.Status).HasDefaultValue(true);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RecordActions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_RecordAction_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.DonateDate).HasColumnType("date");

                entity.Property(e => e.DonatorCardNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.Status).HasDefaultValue(true);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK__Transacti__Campa__4CA06362");

                entity.HasOne(d => d.Donator)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.DonatorId)
                    .HasConstraintName("FK_Transaction_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50).HasDefaultValue(true);

                entity.Property(e => e.Uid).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
