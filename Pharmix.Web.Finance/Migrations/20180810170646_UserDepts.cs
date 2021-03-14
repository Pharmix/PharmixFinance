using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pharmix.Web.Migrations
{
    public partial class UserDepts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDepartment",
                schema: "trusts",
                columns: table => new
                {
                    UserDepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepartment", x => x.UserDepartmentId);
                    table.ForeignKey(
                        name: "FK_UserDepartment_IdentityUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDepartment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "trusts",
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartment_ApplicationUserId",
                schema: "trusts",
                table: "UserDepartment",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartment_DepartmentId",
                schema: "trusts",
                table: "UserDepartment",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDepartment",
                schema: "trusts");
        }
    }
}
