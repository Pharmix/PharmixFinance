using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pharmix.Web.Migrations
{
    public partial class CustomerEntityChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson2",
                table: "Customers",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactNumber2",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactPerson1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactPerson2",
                table: "Customers");
        }
    }
}
