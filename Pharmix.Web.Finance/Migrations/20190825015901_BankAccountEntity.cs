using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pharmix.Web.Migrations
{
    public partial class BankAccountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuardianAge",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GuardianName",
                table: "Customers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMarried",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LocationOfBusiness",
                table: "Customers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfBusiness",
                table: "Customers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidentialAddress",
                table: "Customers",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountNumber = table.Column<int>(nullable: false),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(maxLength: 100, nullable: true),
                    BranchName = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    IFSCCode = table.Column<string>(maxLength: 20, nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BankAccountId",
                table: "Loans",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_CustomerId",
                table: "BankAccounts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_BankAccounts_BankAccountId",
                table: "Loans",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id"
                //onDelete: ReferentialAction.Cascade
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_BankAccounts_BankAccountId",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Loans_BankAccountId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GuardianAge",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GuardianName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsMarried",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LocationOfBusiness",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NameOfBusiness",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ResidentialAddress",
                table: "Customers");
        }
    }
}
