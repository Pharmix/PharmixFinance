using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pharmix.Web.Migrations
{
    public partial class TrustDept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "pat",
                table: "PatientAppointment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "trusts",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    TrustId = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_Trusts_TrustId",
                        column: x => x.TrustId,
                        principalSchema: "trusts",
                        principalTable: "Trusts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAppointment_DepartmentId",
                schema: "pat",
                table: "PatientAppointment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_TrustId",
                schema: "trusts",
                table: "Department",
                column: "TrustId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAppointment_Department_DepartmentId",
                schema: "pat",
                table: "PatientAppointment",
                column: "DepartmentId",
                principalSchema: "trusts",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAppointment_Department_DepartmentId",
                schema: "pat",
                table: "PatientAppointment");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "trusts");

            migrationBuilder.DropIndex(
                name: "IX_PatientAppointment_DepartmentId",
                schema: "pat",
                table: "PatientAppointment");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "pat",
                table: "PatientAppointment");
        }
    }
}
