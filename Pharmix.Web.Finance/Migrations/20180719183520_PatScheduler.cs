using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pharmix.Web.Migrations
{
    public partial class PatScheduler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pat");

            migrationBuilder.RenameTable(
                name: "Patient",
                newSchema: "pat");

            migrationBuilder.RenameColumn(
                name: "GPSurename",
                schema: "PREG",
                table: "PrimaryCareContact",
                newName: "HealtVisitor");

            migrationBuilder.RenameColumn(
                name: "Relaton",
                schema: "PREG",
                table: "NextOfKin",
                newName: "Relation");

            migrationBuilder.AddColumn<string>(
                name: "GPSurname",
                schema: "PREG",
                table: "PrimaryCareContact",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PatientAppointment",
                schema: "pat",
                columns: table => new
                {
                    PatientAppointmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppointmentDateTime = table.Column<DateTime>(nullable: false),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAppointment", x => x.PatientAppointmentId);
                    table.ForeignKey(
                        name: "FK_PatientAppointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "pat",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EthnicOrigin",
                schema: "PREG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    Bangladesh = table.Column<int>(nullable: true),
                    Caribean = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    European = table.Column<int>(nullable: true),
                    FarEastAsia = table.Column<int>(nullable: true),
                    India = table.Column<int>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    MidleEast = table.Column<int>(nullable: true),
                    NorthAfrica = table.Column<int>(nullable: true),
                    OtherBabysFather = table.Column<string>(nullable: true),
                    OtherYou = table.Column<string>(nullable: true),
                    Pakistan = table.Column<int>(nullable: true),
                    PregnancyId = table.Column<int>(nullable: false),
                    SouthEastAsia = table.Column<int>(nullable: true),
                    SubSahara = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthnicOrigin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EthnicOrigin_Pregnancy_PregnancyId",
                        column: x => x.PregnancyId,
                        principalSchema: "PREG",
                        principalTable: "Pregnancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentalHealth",
                schema: "PREG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anxious1st = table.Column<bool>(nullable: false),
                    Anxious2nd = table.Column<bool>(nullable: false),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Depressed1st = table.Column<bool>(nullable: false),
                    Depressed2nd = table.Column<bool>(nullable: false),
                    Detail = table.Column<string>(nullable: true),
                    FamilyHistory = table.Column<bool>(nullable: false),
                    Interest1st = table.Column<bool>(nullable: false),
                    Interest2nd = table.Column<bool>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    MentalIllness = table.Column<bool>(nullable: false),
                    NeedSomething1st = table.Column<bool>(nullable: false),
                    NeedSomething2nd = table.Column<bool>(nullable: false),
                    PartnerHasHistory = table.Column<bool>(nullable: false),
                    PregnancyId = table.Column<int>(nullable: false),
                    PreviousTreatment = table.Column<bool>(nullable: false),
                    RefferalRequired1st = table.Column<bool>(nullable: false),
                    RefferalRequired2nd = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentalHealth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MentalHealth_Pregnancy_PregnancyId",
                        column: x => x.PregnancyId,
                        principalSchema: "PREG",
                        principalTable: "Pregnancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartnerDetail",
                schema: "PREG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: true),
                    Employed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    Occupation = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    PregnancyId = table.Column<int>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    UKCitizenshipStatus = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true),
                    YearOfEntry = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerDetail_Pregnancy_PregnancyId",
                        column: x => x.PregnancyId,
                        principalSchema: "PREG",
                        principalTable: "Pregnancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YourDetail",
                schema: "PREG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CitizenshipStatus = table.Column<string>(nullable: true),
                    CountryOfBirth = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Disability = table.Column<bool>(nullable: false),
                    Faith = table.Column<string>(nullable: true),
                    FamilyName = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    MarriageStatus = table.Column<int>(nullable: true),
                    PregnancyId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true),
                    YearOfEntry = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YourDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YourDetail_Pregnancy_PregnancyId",
                        column: x => x.PregnancyId,
                        principalSchema: "PREG",
                        principalTable: "Pregnancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAppointment_PatientId",
                schema: "pat",
                table: "PatientAppointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_EthnicOrigin_PregnancyId",
                schema: "PREG",
                table: "EthnicOrigin",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_MentalHealth_PregnancyId",
                schema: "PREG",
                table: "MentalHealth",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerDetail_PregnancyId",
                schema: "PREG",
                table: "PartnerDetail",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_YourDetail_PregnancyId",
                schema: "PREG",
                table: "YourDetail",
                column: "PregnancyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAppointment",
                schema: "pat");

            migrationBuilder.DropTable(
                name: "EthnicOrigin",
                schema: "PREG");

            migrationBuilder.DropTable(
                name: "MentalHealth",
                schema: "PREG");

            migrationBuilder.DropTable(
                name: "PartnerDetail",
                schema: "PREG");

            migrationBuilder.DropTable(
                name: "YourDetail",
                schema: "PREG");

            migrationBuilder.DropColumn(
                name: "GPSurname",
                schema: "PREG",
                table: "PrimaryCareContact");

            migrationBuilder.RenameTable(
                name: "Patient",
                schema: "pat");

            migrationBuilder.RenameColumn(
                name: "HealtVisitor",
                schema: "PREG",
                table: "PrimaryCareContact",
                newName: "GPSurename");

            migrationBuilder.RenameColumn(
                name: "Relation",
                schema: "PREG",
                table: "NextOfKin",
                newName: "Relaton");
        }
    }
}
