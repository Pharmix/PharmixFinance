using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pharmix.Web.Migrations
{
    public partial class ApptUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentNotes",
                schema: "pat",
                table: "PatientAppointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancelNotes",
                schema: "pat",
                table: "PatientAppointment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentNotes",
                schema: "pat",
                table: "PatientAppointment");

            migrationBuilder.DropColumn(
                name: "CancelNotes",
                schema: "pat",
                table: "PatientAppointment");
        }
    }
}
