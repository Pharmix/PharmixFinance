using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pharmix.Web.Migrations
{
    public partial class AptIntrvlUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentInterval");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentIntervalMins",
                schema: "trusts",
                table: "Trusts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FridayEndTiming",
                schema: "trusts",
                table: "Trusts",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MondayEndTiming",
                schema: "trusts",
                table: "Trusts",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaturdayEndTiming",
                schema: "trusts",
                table: "Trusts",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SundayEndTiming",
                schema: "trusts",
                table: "Trusts",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThursdayEndTiming",
                schema: "trusts",
                table: "Trusts",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TuesdayEndTiming",
                schema: "trusts",
                table: "Trusts",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WednesdayEndTiming",
                schema: "trusts",
                table: "Trusts",
                maxLength: 12,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentIntervalMins",
                schema: "trusts",
                table: "Trusts");

            migrationBuilder.DropColumn(
                name: "FridayEndTiming",
                schema: "trusts",
                table: "Trusts");

            migrationBuilder.DropColumn(
                name: "MondayEndTiming",
                schema: "trusts",
                table: "Trusts");

            migrationBuilder.DropColumn(
                name: "SaturdayEndTiming",
                schema: "trusts",
                table: "Trusts");

            migrationBuilder.DropColumn(
                name: "SundayEndTiming",
                schema: "trusts",
                table: "Trusts");

            migrationBuilder.DropColumn(
                name: "ThursdayEndTiming",
                schema: "trusts",
                table: "Trusts");

            migrationBuilder.DropColumn(
                name: "TuesdayEndTiming",
                schema: "trusts",
                table: "Trusts");

            migrationBuilder.DropColumn(
                name: "WednesdayEndTiming",
                schema: "trusts",
                table: "Trusts");

            migrationBuilder.CreateTable(
                name: "AppointmentInterval",
                columns: table => new
                {
                    AppointmentIntervalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    IntervalMins = table.Column<int>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    StartTime = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentInterval", x => x.AppointmentIntervalId);
                });
        }
    }
}
