﻿// <auto-generated />
using System;
using Donation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Donation.Data.Migrations
{
    [DbContext(typeof(DonationContext))]
    partial class DonationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Donation.Data.Entities.Campaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CampaignName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DonationCaseId")
                        .HasColumnType("int");

                    b.Property<double?>("Goal")
                        .HasColumnType("float");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampaignId");

                    b.HasIndex("DonationCaseId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("Donation.Data.Entities.DonationCase", b =>
                {
                    b.Property<int>("DonationCaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonationCaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("DonationCaseId");

                    b.ToTable("DonationCase");
                });

            modelBuilder.Entity("Donation.Data.Entities.Fanpage", b =>
                {
                    b.Property<int>("FanpageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("FanpageId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Fanpage");
                });

            modelBuilder.Entity("Donation.Data.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("PaymentId");

                    b.HasIndex("CampaignId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Donation.Data.Entities.PaymentEvidence", b =>
                {
                    b.Property<int>("PaymentEvidenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("PaymentEvidenceDate")
                        .HasColumnType("date");

                    b.Property<string>("PaymentEvidenceImage")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("PaymentEvidenceId");

                    b.HasIndex("ProductId");

                    b.ToTable("PaymentEvidence");
                });

            modelBuilder.Entity("Donation.Data.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ProductId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Donation.Data.Entities.RecordAction", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("datetime");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RecordId")
                        .HasName("PK__RecordAc__FBDF78E94BB1B9CF");

                    b.HasIndex("UserId");

                    b.ToTable("RecordAction");
                });

            modelBuilder.Entity("Donation.Data.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true)
                        .HasMaxLength(20);

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Donation.Data.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DonateDate")
                        .HasColumnType("date");

                    b.Property<string>("DonatorCardNumber")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<int?>("DonatorId")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("TransactionId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("DonatorId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("Donation.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Uid")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Donation.Data.Entities.Campaign", b =>
                {
                    b.HasOne("Donation.Data.Entities.DonationCase", "DonationCase")
                        .WithMany("Campaigns")
                        .HasForeignKey("DonationCaseId")
                        .HasConstraintName("FK__Campaign__Donati__47DBAE45");

                    b.HasOne("Donation.Data.Entities.User", "Organization")
                        .WithMany("Campaigns")
                        .HasForeignKey("OrganizationId")
                        .HasConstraintName("FK_Campaign_User");
                });

            modelBuilder.Entity("Donation.Data.Entities.Fanpage", b =>
                {
                    b.HasOne("Donation.Data.Entities.User", "Organization")
                        .WithMany("Fanpages")
                        .HasForeignKey("OrganizationId")
                        .HasConstraintName("FK_Fanpage_User");
                });

            modelBuilder.Entity("Donation.Data.Entities.Payment", b =>
                {
                    b.HasOne("Donation.Data.Entities.Campaign", "Campaign")
                        .WithMany("Payments")
                        .HasForeignKey("CampaignId")
                        .HasConstraintName("FK_Payment_Campaign");
                });

            modelBuilder.Entity("Donation.Data.Entities.PaymentEvidence", b =>
                {
                    b.HasOne("Donation.Data.Entities.Product", "Product")
                        .WithMany("PaymentEvidences")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_PaymentEvidence_Product");
                });

            modelBuilder.Entity("Donation.Data.Entities.Product", b =>
                {
                    b.HasOne("Donation.Data.Entities.Payment", "Payment")
                        .WithMany("Products")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK__Product__Payment__440B1D61");
                });

            modelBuilder.Entity("Donation.Data.Entities.RecordAction", b =>
                {
                    b.HasOne("Donation.Data.Entities.User", "User")
                        .WithMany("RecordActions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_RecordAction_User");
                });

            modelBuilder.Entity("Donation.Data.Entities.Transaction", b =>
                {
                    b.HasOne("Donation.Data.Entities.Campaign", "Campaign")
                        .WithMany("Transactions")
                        .HasForeignKey("CampaignId")
                        .HasConstraintName("FK__Transacti__Campa__4CA06362");

                    b.HasOne("Donation.Data.Entities.User", "Donator")
                        .WithMany("Transactions")
                        .HasForeignKey("DonatorId")
                        .HasConstraintName("FK_Transaction_User");
                });

            modelBuilder.Entity("Donation.Data.Entities.User", b =>
                {
                    b.HasOne("Donation.Data.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_User_Role");
                });
#pragma warning restore 612, 618
        }
    }
}
