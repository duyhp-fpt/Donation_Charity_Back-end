using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Donation.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonationCase",
                columns: table => new
                {
                    DonationCaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationCaseName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationCase", x => x.DonationCaseId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(fixedLength: true, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    RoleId = table.Column<int>(nullable: true),
                    Uid = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    CampaignId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignName = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(type: "date", nullable: true),
                    Image = table.Column<string>(maxLength: 50, nullable: true),
                    DonationCaseId = table.Column<int>(nullable: true),
                    CardNumber = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Status = table.Column<bool>(nullable: true),
                    Goal = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignId);
                    table.ForeignKey(
                        name: "FK__Campaign__Donati__47DBAE45",
                        column: x => x.DonationCaseId,
                        principalTable: "DonationCase",
                        principalColumn: "DonationCaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaign_User",
                        column: x => x.OrganizationId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fanpage",
                columns: table => new
                {
                    FanpageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(maxLength: 100, nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fanpage", x => x.FanpageId);
                    table.ForeignKey(
                        name: "FK_Fanpage_User",
                        column: x => x.OrganizationId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecordAction",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(maxLength: 100, nullable: true),
                    Time = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RecordAc__FBDF78E94BB1B9CF", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_RecordAction_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    TotalPrice = table.Column<double>(nullable: true),
                    Status = table.Column<bool>(nullable: true),
                    CampaignId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Campaign",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonatorId = table.Column<int>(nullable: true),
                    CampaignId = table.Column<int>(nullable: true),
                    Amount = table.Column<double>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DonateDate = table.Column<DateTime>(type: "date", nullable: true),
                    DonatorCardNumber = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK__Transacti__Campa__4CA06362",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_User",
                        column: x => x.DonatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 100, nullable: true),
                    Price = table.Column<double>(nullable: true),
                    Amount = table.Column<double>(nullable: true),
                    PaymentId = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__Product__Payment__440B1D61",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentEvidence",
                columns: table => new
                {
                    PaymentEvidenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentEvidenceImage = table.Column<string>(maxLength: 50, nullable: true),
                    PaymentEvidenceDate = table.Column<DateTime>(type: "date", nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentEvidence", x => x.PaymentEvidenceId);
                    table.ForeignKey(
                        name: "FK_PaymentEvidence_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_DonationCaseId",
                table: "Campaign",
                column: "DonationCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_OrganizationId",
                table: "Campaign",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Fanpage_OrganizationId",
                table: "Fanpage",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CampaignId",
                table: "Payment",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentEvidence_ProductId",
                table: "PaymentEvidence",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PaymentId",
                table: "Product",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordAction_UserId",
                table: "RecordAction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CampaignId",
                table: "Transaction",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_DonatorId",
                table: "Transaction",
                column: "DonatorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fanpage");

            migrationBuilder.DropTable(
                name: "PaymentEvidence");

            migrationBuilder.DropTable(
                name: "RecordAction");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "DonationCase");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
