using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pharmix.Web.Migrations
{
    public partial class CustomerEntityChages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RepaymentPeriod",
                table: "Loans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepaymentTerms",
                table: "Loans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepaymentPeriod",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "RepaymentTerms",
                table: "Loans");
        }
    }
}
