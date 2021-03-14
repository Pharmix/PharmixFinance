using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pharmix.Web.Migrations
{
    public partial class CustomerContactEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_BankAccounts_BankAccountId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ContactNumber1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactNumber2",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactPerson1",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "ContactPerson2",
                table: "Customers",
                newName: "LeaderName");

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Loans",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Customers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactNumber = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerContacts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_CustomerId",
                table: "CustomerContacts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_BankAccounts_BankAccountId",
                table: "Loans",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_BankAccounts_BankAccountId",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "CustomerContacts");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LeaderName",
                table: "Customers",
                newName: "ContactPerson2");

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber1",
                table: "Customers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber2",
                table: "Customers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson1",
                table: "Customers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_BankAccounts_BankAccountId",
                table: "Loans",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
