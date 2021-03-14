using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Pharmix.Web.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "trusts");

            migrationBuilder.EnsureSchema(
                name: "PREG");

            migrationBuilder.EnsureSchema(
                name: "INTG");

            migrationBuilder.EnsureSchema(
                name: "ISO");

            migrationBuilder.EnsureSchema(
                name: "task");

            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true),
                    KeyId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Version = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    ContactType = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false),
                    Phone1 = table.Column<string>(maxLength: 50, nullable: true),
                    Phone2 = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupervisorRequestType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisorRequestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegratedSystem",
                schema: "INTG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    OrderNumberFieldName = table.Column<string>(nullable: true),
                    OrderStatusFieldName = table.Column<string>(nullable: true),
                    Type1ConnectionString = table.Column<string>(nullable: true),
                    Type1ParameterString = table.Column<string>(nullable: true),
                    Type1StoredProcedureName = table.Column<string>(nullable: true),
                    Type2QueryString = table.Column<int>(nullable: false),
                    Type2ResultTemplate = table.Column<string>(nullable: true),
                    Type2ServiceUrl = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegratedSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationOrderClassification",
                schema: "INTG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationOrderClassification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationOrderLocation",
                schema: "INTG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    LocationCode = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationOrderLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationOrderProgress",
                schema: "INTG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationOrderProgress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Isolator",
                schema: "ISO",
                columns: table => new
                {
                    IsolatorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abbriviation = table.Column<string>(nullable: true),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    OfflineEndDate = table.Column<DateTime>(nullable: true),
                    OfflineShifts = table.Column<string>(nullable: true),
                    OfflineStartDate = table.Column<DateTime>(nullable: true),
                    TotalNumberOfDosesPerSession = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isolator", x => x.IsolatorId);
                });

            migrationBuilder.CreateTable(
                name: "IsolatorProcedure",
                schema: "ISO",
                columns: table => new
                {
                    IsolatorProcedureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    ProcedureTypeId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsolatorProcedure", x => x.IsolatorProcedureId);
                });

            migrationBuilder.CreateTable(
                name: "IsolatorShift",
                schema: "ISO",
                columns: table => new
                {
                    ShiftId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    ShiftTitle = table.Column<string>(nullable: true),
                    StartTime = table.Column<string>(nullable: true),
                    TotalShiftDurationInMins = table.Column<double>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsolatorShift", x => x.ShiftId);
                });

            migrationBuilder.CreateTable(
                name: "Reminder",
                schema: "task",
                columns: table => new
                {
                    ReminderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    FromDateTime = table.Column<DateTime>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    ReminderEntityTypeId = table.Column<int>(nullable: false),
                    ReminderModuleId = table.Column<int>(nullable: false),
                    ReminderModuleKeyId = table.Column<string>(nullable: true),
                    ReminderTypeId = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    TodDateTime = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder", x => x.ReminderId);
                });

            migrationBuilder.CreateTable(
                name: "ReminderProgressStatus",
                schema: "task",
                columns: table => new
                {
                    ReminderProgressStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderProgressStatus", x => x.ReminderProgressStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Trusts",
                schema: "trusts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    FridayOpenTiming = table.Column<string>(maxLength: 12, nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    LogoImage = table.Column<byte[]>(nullable: true),
                    LogoImageName = table.Column<string>(maxLength: 200, nullable: true),
                    MondayOpenTiming = table.Column<string>(maxLength: 12, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    SaturdayOpenTiming = table.Column<string>(maxLength: 12, nullable: true),
                    SundayOpenTiming = table.Column<string>(maxLength: 12, nullable: true),
                    ThursdayOpenTiming = table.Column<string>(maxLength: 12, nullable: true),
                    TuesdayOpenTiming = table.Column<string>(maxLength: 12, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true),
                    WednesdayOpenTiming = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trusts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(maxLength: 250, nullable: true),
                    Address2 = table.Column<string>(maxLength: 250, nullable: true),
                    AddressTypeId = table.Column<int>(nullable: false),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false),
                    State = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CssClass = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    IsShowMenu = table.Column<bool>(nullable: true),
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    ModuleId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    ParentPermissionId = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: true),
                    Url = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationOrder",
                schema: "INTG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdministeredDate = table.Column<DateTime>(nullable: true),
                    AllocatedIsolatorId = table.Column<int>(nullable: false),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    BookedInDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    ExternalBarcode = table.Column<string>(nullable: true),
                    ExternalOrderId = table.Column<string>(nullable: true),
                    IntegratedSystemId = table.Column<int>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    OrderLastProgressId = table.Column<int>(nullable: false),
                    OrderlastClassificationId = table.Column<int>(nullable: true),
                    PriorityId = table.Column<int>(nullable: false),
                    RequiredDate = table.Column<DateTime>(nullable: true),
                    RequiredPreperationTimeInMins = table.Column<int>(nullable: false),
                    ScheduledDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntegrationOrder_IntegratedSystem_IntegratedSystemId",
                        column: x => x.IntegratedSystemId,
                        principalSchema: "INTG",
                        principalTable: "IntegratedSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntegrationOrder_IntegrationOrderClassification_OrderlastClassificationId",
                        column: x => x.OrderlastClassificationId,
                        principalSchema: "INTG",
                        principalTable: "IntegrationOrderClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderTrackingDevices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    BatteryPercent = table.Column<decimal>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    LastCharged = table.Column<DateTime>(nullable: true),
                    LastHeartBeat = table.Column<DateTime>(nullable: true),
                    LastLocationId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Serial = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTrackingDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTrackingDevices_IntegrationOrderLocation_LastLocationId",
                        column: x => x.LastLocationId,
                        principalSchema: "INTG",
                        principalTable: "IntegrationOrderLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IsolatorMappedProcedure",
                schema: "ISO",
                columns: table => new
                {
                    IsolatorMappedProcedureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsolatorId = table.Column<int>(nullable: false),
                    ProcedureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsolatorMappedProcedure", x => x.IsolatorMappedProcedureId);
                    table.ForeignKey(
                        name: "FK_IsolatorMappedProcedure_Isolator_IsolatorId",
                        column: x => x.IsolatorId,
                        principalSchema: "ISO",
                        principalTable: "Isolator",
                        principalColumn: "IsolatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IsolatorMappedProcedure_IsolatorProcedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalSchema: "ISO",
                        principalTable: "IsolatorProcedure",
                        principalColumn: "IsolatorProcedureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReminderInvitation",
                schema: "task",
                columns: table => new
                {
                    ReminderInvitationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    ReminderId = table.Column<int>(nullable: false),
                    SenderUserName = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderInvitation", x => x.ReminderInvitationId);
                    table.ForeignKey(
                        name: "FK_ReminderInvitation_Reminder_ReminderId",
                        column: x => x.ReminderId,
                        principalSchema: "task",
                        principalTable: "Reminder",
                        principalColumn: "ReminderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReminderProgress",
                schema: "task",
                columns: table => new
                {
                    ReminderProgressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    LastProgressDate = table.Column<DateTime>(nullable: true),
                    ReminderProgressPercent = table.Column<int>(nullable: false),
                    ReminderProgressStatusId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderProgress", x => x.ReminderProgressId);
                    table.ForeignKey(
                        name: "FK_ReminderProgress_ReminderProgressStatus_ReminderProgressStatusId",
                        column: x => x.ReminderProgressStatusId,
                        principalSchema: "task",
                        principalTable: "ReminderProgressStatus",
                        principalColumn: "ReminderProgressStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    TrustId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Trusts_TrustId",
                        column: x => x.TrustId,
                        principalSchema: "trusts",
                        principalTable: "Trusts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrustContacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactId = table.Column<long>(nullable: false),
                    TrustId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrustContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrustContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrustContacts_Trusts_TrustId",
                        column: x => x.TrustId,
                        principalSchema: "trusts",
                        principalTable: "Trusts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrustModule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleId = table.Column<int>(nullable: false),
                    TrustId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrustModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrustModule_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrustModule_Trusts_TrustId",
                        column: x => x.TrustId,
                        principalSchema: "trusts",
                        principalTable: "Trusts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTrust",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrustId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrust", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrust_Trusts_TrustId",
                        column: x => x.TrustId,
                        principalSchema: "trusts",
                        principalTable: "Trusts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    AddressId = table.Column<long>(nullable: true),
                    AlternativeTel = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: true),
                    IsResetPasswordRequired = table.Column<bool>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUser_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrustAddresses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<long>(nullable: false),
                    TrustId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrustAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrustAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrustAddresses_Trusts_TrustId",
                        column: x => x.TrustId,
                        principalSchema: "trusts",
                        principalTable: "Trusts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupervisorRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    CurrentOrderId = table.Column<int>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    IsolatorId = table.Column<int>(nullable: false),
                    LatestRequestStatus = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    RequestedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 256, nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisorRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupervisorRequest_IntegrationOrder_CurrentOrderId",
                        column: x => x.CurrentOrderId,
                        principalSchema: "INTG",
                        principalTable: "IntegrationOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupervisorRequest_Isolator_IsolatorId",
                        column: x => x.IsolatorId,
                        principalSchema: "ISO",
                        principalTable: "Isolator",
                        principalColumn: "IsolatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupervisorRequest_SupervisorRequestType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "SupervisorRequestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationOrderTracking",
                schema: "INTG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IntegrationOrderId = table.Column<int>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    OrderCurrentLocationId = table.Column<int>(nullable: true),
                    OrderLastClassificationId = table.Column<int>(nullable: true),
                    OrderLastProgressId = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationOrderTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntegrationOrderTracking_IntegrationOrder_IntegrationOrderId",
                        column: x => x.IntegrationOrderId,
                        principalSchema: "INTG",
                        principalTable: "IntegrationOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntegrationOrderTracking_IntegrationOrderLocation_OrderCurrentLocationId",
                        column: x => x.OrderCurrentLocationId,
                        principalSchema: "INTG",
                        principalTable: "IntegrationOrderLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IntegrationOrderTracking_IntegrationOrderClassification_OrderLastClassificationId",
                        column: x => x.OrderLastClassificationId,
                        principalSchema: "INTG",
                        principalTable: "IntegrationOrderClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IntegrationOrderTracking_IntegrationOrderProgress_OrderLastProgressId",
                        column: x => x.OrderLastProgressId,
                        principalSchema: "INTG",
                        principalTable: "IntegrationOrderProgress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReminderInvitationMember",
                schema: "task",
                columns: table => new
                {
                    ReminderInvitationMemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    HasRead = table.Column<bool>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    ReadDate = table.Column<DateTime>(nullable: true),
                    RecipientUserName = table.Column<string>(nullable: true),
                    ReminderInvitationId = table.Column<int>(nullable: false),
                    ReminderProgressId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderInvitationMember", x => x.ReminderInvitationMemberId);
                    table.ForeignKey(
                        name: "FK_ReminderInvitationMember_ReminderInvitation_ReminderInvitationId",
                        column: x => x.ReminderInvitationId,
                        principalSchema: "task",
                        principalTable: "ReminderInvitation",
                        principalColumn: "ReminderInvitationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReminderInvitationMember_ReminderProgress_ReminderProgressId",
                        column: x => x.ReminderProgressId,
                        principalSchema: "task",
                        principalTable: "ReminderProgress",
                        principalColumn: "ReminderProgressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionGroup_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: true),
                    PermissionId = table.Column<int>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(maxLength: 500, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 500, nullable: true),
                    AddressLine3 = table.Column<string>(maxLength: 500, nullable: true),
                    AlternativeTel = table.Column<string>(maxLength: 25, nullable: true),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    City = table.Column<string>(maxLength: 200, nullable: true),
                    County = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 200, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    LastVisitedDate = table.Column<DateTime>(nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 25, nullable: true),
                    NhsNumber = table.Column<string>(nullable: true),
                    PasNumber = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(maxLength: 10, nullable: true),
                    RegisteredDate = table.Column<DateTime>(nullable: false),
                    RequiresPasswordReset = table.Column<bool>(nullable: true),
                    Surname = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IsolatorStaffAllocation",
                schema: "ISO",
                columns: table => new
                {
                    IsolatorStaffAllocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllocatedDate = table.Column<DateTime>(nullable: false),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    DailyRecurringTypeId = table.Column<int>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    IsRecurring = table.Column<bool>(nullable: false),
                    IsUsingIsolatorNow = table.Column<bool>(nullable: false),
                    IsolatorId = table.Column<int>(nullable: false),
                    IsolatorShiftId = table.Column<int>(nullable: false),
                    ParentAllocationId = table.Column<int>(nullable: true),
                    RecurringEndDate = table.Column<DateTime>(nullable: true),
                    RecurringTypeId = table.Column<int>(nullable: false),
                    StaffId = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true),
                    WeeklyRecurringWeekdays = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsolatorStaffAllocation", x => x.IsolatorStaffAllocationId);
                    table.ForeignKey(
                        name: "FK_IsolatorStaffAllocation_Isolator_IsolatorId",
                        column: x => x.IsolatorId,
                        principalSchema: "ISO",
                        principalTable: "Isolator",
                        principalColumn: "IsolatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IsolatorStaffAllocation_IsolatorShift_IsolatorShiftId",
                        column: x => x.IsolatorShiftId,
                        principalSchema: "ISO",
                        principalTable: "IsolatorShift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IsolatorStaffAllocation_IsolatorStaffAllocation_ParentAllocationId",
                        column: x => x.ParentAllocationId,
                        principalSchema: "ISO",
                        principalTable: "IsolatorStaffAllocation",
                        principalColumn: "IsolatorStaffAllocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IsolatorStaffAllocation_IdentityUser_StaffId",
                        column: x => x.StaffId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupervisorRequestTracking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    LastModifiedUser = table.Column<string>(nullable: true),
                    RequestId = table.Column<int>(nullable: false),
                    RequestStatus = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisorRequestTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupervisorRequestTracking_SupervisorRequest_RequestId",
                        column: x => x.RequestId,
                        principalTable: "SupervisorRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pregnancy",
                schema: "PREG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    EDD = table.Column<DateTime>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    MaternityUnit = table.Column<string>(maxLength: 25, nullable: true),
                    NHSNumber = table.Column<string>(maxLength: 25, nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregnancy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregnancy_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationOrderPreperation",
                schema: "ISO",
                columns: table => new
                {
                    IntegrationOrderPreperationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IntegrationOrderId = table.Column<int>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    IsolatorId = table.Column<int>(nullable: false),
                    IsolatorStaffAllocationId = table.Column<int>(nullable: true),
                    PreperationDateTime = table.Column<DateTime>(nullable: false),
                    PreperationStatusId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationOrderPreperation", x => x.IntegrationOrderPreperationId);
                    table.ForeignKey(
                        name: "FK_IntegrationOrderPreperation_IntegrationOrder_IntegrationOrderId",
                        column: x => x.IntegrationOrderId,
                        principalSchema: "INTG",
                        principalTable: "IntegrationOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntegrationOrderPreperation_Isolator_IsolatorId",
                        column: x => x.IsolatorId,
                        principalSchema: "ISO",
                        principalTable: "Isolator",
                        principalColumn: "IsolatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntegrationOrderPreperation_IsolatorStaffAllocation_IsolatorStaffAllocationId",
                        column: x => x.IsolatorStaffAllocationId,
                        principalSchema: "ISO",
                        principalTable: "IsolatorStaffAllocation",
                        principalColumn: "IsolatorStaffAllocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationNeed",
                schema: "PREG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    AssistanceRequired = table.Column<bool>(nullable: false),
                    AssistanceRequiredDetail = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    FirstLanguage = table.Column<string>(nullable: true),
                    InterpreterPhone = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    PreferedLanguage = table.Column<string>(nullable: true),
                    PreferredAssistance = table.Column<string>(nullable: true),
                    PregnancyId = table.Column<int>(nullable: false),
                    SpeakEnglish = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationNeed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunicationNeed_Pregnancy_PregnancyId",
                        column: x => x.PregnancyId,
                        principalSchema: "PREG",
                        principalTable: "Pregnancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
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
                    IsArchived = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber1 = table.Column<string>(nullable: true),
                    PhoneNumber2 = table.Column<string>(nullable: true),
                    PregnancyId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyContact_Pregnancy_PregnancyId",
                        column: x => x.PregnancyId,
                        principalSchema: "PREG",
                        principalTable: "Pregnancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaternityContact",
                schema: "PREG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmbulancePhone = table.Column<string>(nullable: true),
                    AntenatalClinicPhone = table.Column<string>(nullable: true),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CommunityOfficePhone = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    DeliverySuitePhone = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    MaternityUnit = table.Column<string>(nullable: true),
                    MaternityUnitPhone = table.Column<string>(nullable: true),
                    Midwife = table.Column<string>(nullable: true),
                    MidwifePhone = table.Column<string>(nullable: true),
                    PregnancyId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaternityContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaternityContact_Pregnancy_PregnancyId",
                        column: x => x.PregnancyId,
                        principalSchema: "PREG",
                        principalTable: "Pregnancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                schema: "PREG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AandE = table.Column<bool>(nullable: false),
                    AandEDetail = table.Column<string>(nullable: true),
                    Allergies = table.Column<bool>(nullable: false),
                    AllergiesDetail = table.Column<string>(nullable: true),
                    AnaestheticProblem = table.Column<bool>(nullable: false),
                    AnaestheticProblemDetail = table.Column<string>(nullable: true),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    AsthmaChestProblem = table.Column<bool>(nullable: false),
                    AsthmaChestProblemDetail = table.Column<string>(nullable: true),
                    AutoimmuneDisease = table.Column<bool>(nullable: false),
                    AutoimmuneDiseaseDetail = table.Column<string>(nullable: true),
                    BackProblem = table.Column<bool>(nullable: false),
                    BackProblemDetail = table.Column<string>(nullable: true),
                    BloodClottingDisorder = table.Column<bool>(nullable: false),
                    BloodClottingDisorderDetail = table.Column<string>(nullable: true),
                    BloodTransfution = table.Column<bool>(nullable: false),
                    BloodTransfutionDetail = table.Column<string>(nullable: true),
                    Cancer = table.Column<bool>(nullable: false),
                    CancerDetail = table.Column<string>(nullable: true),
                    CervicalSmear = table.Column<bool>(nullable: false),
                    CervicalSmearDate = table.Column<DateTime>(nullable: true),
                    CervicalSmearResult = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    Diabetes = table.Column<bool>(nullable: false),
                    DiabetesDetail = table.Column<string>(nullable: true),
                    EpilepsyNeurogicalProblem = table.Column<bool>(nullable: false),
                    ExposureToxicSubstance = table.Column<bool>(nullable: false),
                    ExposureToxicSubstanceDetail = table.Column<string>(nullable: true),
                    FemaleCIrcumcisionDetail = table.Column<string>(nullable: true),
                    FemaleCircumcision = table.Column<bool>(nullable: false),
                    FertilityProblem = table.Column<bool>(nullable: false),
                    FertilityProblemDetail = table.Column<string>(nullable: true),
                    FolicAcidTablet = table.Column<bool>(nullable: false),
                    FolicAcidTabletDate = table.Column<DateTime>(nullable: true),
                    FolicAcidTabletDose = table.Column<float>(nullable: false),
                    FolicAcidTabletDoseChanged = table.Column<bool>(nullable: true),
                    GastroIntestinalProblem = table.Column<bool>(nullable: false),
                    GastroIntestinalProblemDetail = table.Column<string>(nullable: true),
                    GeneticInheritedDisorder = table.Column<bool>(nullable: false),
                    GeneticInheritedDisorderDetail = table.Column<string>(nullable: true),
                    GenitalInfection = table.Column<bool>(nullable: false),
                    GenitalInfectionDetail = table.Column<string>(nullable: true),
                    GynaeHistory = table.Column<bool>(nullable: false),
                    GynaeHistoryDetail = table.Column<string>(nullable: true),
                    HeartProblem = table.Column<bool>(nullable: false),
                    HeartProblemDetail = table.Column<string>(nullable: true),
                    HighBloodPreassure = table.Column<bool>(nullable: false),
                    HighBloodPreassureDetail = table.Column<string>(nullable: true),
                    ITUorHDU = table.Column<bool>(nullable: false),
                    ITUorHDUDetail = table.Column<string>(nullable: true),
                    Incontinence = table.Column<bool>(nullable: false),
                    IncontinenceDetail = table.Column<string>(nullable: true),
                    Infection = table.Column<bool>(nullable: false),
                    InfectionDetail = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    KidneyUrinaryProblem = table.Column<bool>(nullable: false),
                    KidneyUrinaryProblemDetail = table.Column<string>(nullable: true),
                    LiverDiseas = table.Column<bool>(nullable: false),
                    LiverDiseasLevel = table.Column<string>(maxLength: 1, nullable: true),
                    MedicationLastSixMonth = table.Column<bool>(nullable: false),
                    MedicationLastSixMonthDetail = table.Column<string>(nullable: true),
                    MigraineSevereHeadache = table.Column<bool>(nullable: false),
                    MigraineSevereHeadacheDetail = table.Column<string>(nullable: true),
                    MusculoSkeletalProblem = table.Column<bool>(nullable: false),
                    MusculoSkeletalProblemDetail = table.Column<string>(nullable: true),
                    OnEpilepsyNeurogicalProblemMedication = table.Column<bool>(nullable: false),
                    Operations = table.Column<bool>(nullable: false),
                    OperationsDetail = table.Column<string>(nullable: true),
                    Other = table.Column<bool>(nullable: false),
                    OtherDetail = table.Column<string>(nullable: true),
                    PelvicInjury = table.Column<bool>(nullable: false),
                    PelvicInjuryDetail = table.Column<string>(nullable: true),
                    PhysicalExamination = table.Column<bool>(nullable: false),
                    PhysicalExaminationDetail = table.Column<string>(nullable: true),
                    PregnancyId = table.Column<int>(nullable: false),
                    SickleCellThalassaemia = table.Column<bool>(nullable: false),
                    SickleCellThalassaemiaDetail = table.Column<string>(nullable: true),
                    TBExposur = table.Column<bool>(nullable: false),
                    TBExposurDetail = table.Column<string>(nullable: true),
                    Thrombosis = table.Column<bool>(nullable: false),
                    ThrombosisDetail = table.Column<string>(nullable: true),
                    ThyroidEndocrineProblem = table.Column<bool>(nullable: false),
                    ThyroidEndocrineProblemDetail = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true),
                    VaginalBleeding = table.Column<bool>(nullable: false),
                    VaginalBleedingDetail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Pregnancy_PregnancyId",
                        column: x => x.PregnancyId,
                        principalSchema: "PREG",
                        principalTable: "Pregnancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NextOfKin",
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
                    IsArchived = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PregnancyId = table.Column<int>(nullable: false),
                    Relaton = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NextOfKin_Pregnancy_PregnancyId",
                        column: x => x.PregnancyId,
                        principalSchema: "PREG",
                        principalTable: "Pregnancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanOfCare",
                schema: "PREG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    LeadProfessional = table.Column<string>(nullable: true),
                    PlannedPlaceOfBirth = table.Column<string>(nullable: true),
                    PregnancyId = table.Column<int>(nullable: false),
                    ReasonIfChanged = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanOfCare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanOfCare_Pregnancy_PregnancyId",
                        column: x => x.PregnancyId,
                        principalSchema: "PREG",
                        principalTable: "Pregnancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryCareContact",
                schema: "PREG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchivedDate = table.Column<DateTime>(nullable: true),
                    ArchivedUser = table.Column<string>(nullable: true),
                    Centre = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    GPInitial = table.Column<string>(nullable: true),
                    GPPostcode = table.Column<string>(nullable: true),
                    GPSurename = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    PhoneNumber1 = table.Column<string>(nullable: true),
                    PhoneNumber2 = table.Column<string>(nullable: true),
                    PhoneNumber3 = table.Column<string>(nullable: true),
                    PhoneNumber4 = table.Column<string>(nullable: true),
                    PregnancyId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryCareContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrimaryCareContact_Pregnancy_PregnancyId",
                        column: x => x.PregnancyId,
                        principalSchema: "PREG",
                        principalTable: "Pregnancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_TrustId",
                table: "Group",
                column: "TrustId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_AddressId",
                table: "IdentityUser",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "IdentityUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "IdentityUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrackingDevices_LastLocationId",
                table: "OrderTrackingDevices",
                column: "LastLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_GenderId",
                table: "Patient",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UserId",
                table: "Patient",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_ModuleId",
                table: "Permission",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroup_GroupId",
                table: "PermissionGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroup_PermissionId",
                table: "PermissionGroup",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_GroupId",
                table: "RolePermission",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorRequest_CurrentOrderId",
                table: "SupervisorRequest",
                column: "CurrentOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorRequest_IsolatorId",
                table: "SupervisorRequest",
                column: "IsolatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorRequest_TypeId",
                table: "SupervisorRequest",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorRequestTracking_RequestId",
                table: "SupervisorRequestTracking",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TrustAddresses_AddressId",
                table: "TrustAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TrustAddresses_TrustId",
                table: "TrustAddresses",
                column: "TrustId");

            migrationBuilder.CreateIndex(
                name: "IX_TrustContacts_ContactId",
                table: "TrustContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_TrustContacts_TrustId",
                table: "TrustContacts",
                column: "TrustId");

            migrationBuilder.CreateIndex(
                name: "IX_TrustModule_ModuleId",
                table: "TrustModule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TrustModule_TrustId",
                table: "TrustModule",
                column: "TrustId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrust_TrustId",
                table: "UserTrust",
                column: "TrustId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationOrder_IntegratedSystemId",
                schema: "INTG",
                table: "IntegrationOrder",
                column: "IntegratedSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationOrder_OrderlastClassificationId",
                schema: "INTG",
                table: "IntegrationOrder",
                column: "OrderlastClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationOrderTracking_IntegrationOrderId",
                schema: "INTG",
                table: "IntegrationOrderTracking",
                column: "IntegrationOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationOrderTracking_OrderCurrentLocationId",
                schema: "INTG",
                table: "IntegrationOrderTracking",
                column: "OrderCurrentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationOrderTracking_OrderLastClassificationId",
                schema: "INTG",
                table: "IntegrationOrderTracking",
                column: "OrderLastClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationOrderTracking_OrderLastProgressId",
                schema: "INTG",
                table: "IntegrationOrderTracking",
                column: "OrderLastProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationOrderPreperation_IntegrationOrderId",
                schema: "ISO",
                table: "IntegrationOrderPreperation",
                column: "IntegrationOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationOrderPreperation_IsolatorId",
                schema: "ISO",
                table: "IntegrationOrderPreperation",
                column: "IsolatorId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegrationOrderPreperation_IsolatorStaffAllocationId",
                schema: "ISO",
                table: "IntegrationOrderPreperation",
                column: "IsolatorStaffAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_IsolatorMappedProcedure_IsolatorId",
                schema: "ISO",
                table: "IsolatorMappedProcedure",
                column: "IsolatorId");

            migrationBuilder.CreateIndex(
                name: "IX_IsolatorMappedProcedure_ProcedureId",
                schema: "ISO",
                table: "IsolatorMappedProcedure",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_IsolatorStaffAllocation_IsolatorId",
                schema: "ISO",
                table: "IsolatorStaffAllocation",
                column: "IsolatorId");

            migrationBuilder.CreateIndex(
                name: "IX_IsolatorStaffAllocation_IsolatorShiftId",
                schema: "ISO",
                table: "IsolatorStaffAllocation",
                column: "IsolatorShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_IsolatorStaffAllocation_ParentAllocationId",
                schema: "ISO",
                table: "IsolatorStaffAllocation",
                column: "ParentAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_IsolatorStaffAllocation_StaffId",
                schema: "ISO",
                table: "IsolatorStaffAllocation",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationNeed_PregnancyId",
                schema: "PREG",
                table: "CommunicationNeed",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_PregnancyId",
                schema: "PREG",
                table: "EmergencyContact",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_MaternityContact_PregnancyId",
                schema: "PREG",
                table: "MaternityContact",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_PregnancyId",
                schema: "PREG",
                table: "MedicalHistory",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKin_PregnancyId",
                schema: "PREG",
                table: "NextOfKin",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanOfCare_PregnancyId",
                schema: "PREG",
                table: "PlanOfCare",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregnancy_PatientId",
                schema: "PREG",
                table: "Pregnancy",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryCareContact_PregnancyId",
                schema: "PREG",
                table: "PrimaryCareContact",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReminderInvitation_ReminderId",
                schema: "task",
                table: "ReminderInvitation",
                column: "ReminderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReminderInvitationMember_ReminderInvitationId",
                schema: "task",
                table: "ReminderInvitationMember",
                column: "ReminderInvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReminderInvitationMember_ReminderProgressId",
                schema: "task",
                table: "ReminderInvitationMember",
                column: "ReminderProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_ReminderProgress_ReminderProgressStatusId",
                schema: "task",
                table: "ReminderProgress",
                column: "ReminderProgressStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditInfo");

            migrationBuilder.DropTable(
                name: "OrderTrackingDevices");

            migrationBuilder.DropTable(
                name: "PermissionGroup");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "SupervisorRequestTracking");

            migrationBuilder.DropTable(
                name: "TrustAddresses");

            migrationBuilder.DropTable(
                name: "TrustContacts");

            migrationBuilder.DropTable(
                name: "TrustModule");

            migrationBuilder.DropTable(
                name: "UserTrust");

            migrationBuilder.DropTable(
                name: "IntegrationOrderTracking",
                schema: "INTG");

            migrationBuilder.DropTable(
                name: "IntegrationOrderPreperation",
                schema: "ISO");

            migrationBuilder.DropTable(
                name: "IsolatorMappedProcedure",
                schema: "ISO");

            migrationBuilder.DropTable(
                name: "CommunicationNeed",
                schema: "PREG");

            migrationBuilder.DropTable(
                name: "EmergencyContact",
                schema: "PREG");

            migrationBuilder.DropTable(
                name: "MaternityContact",
                schema: "PREG");

            migrationBuilder.DropTable(
                name: "MedicalHistory",
                schema: "PREG");

            migrationBuilder.DropTable(
                name: "NextOfKin",
                schema: "PREG");

            migrationBuilder.DropTable(
                name: "PlanOfCare",
                schema: "PREG");

            migrationBuilder.DropTable(
                name: "PrimaryCareContact",
                schema: "PREG");

            migrationBuilder.DropTable(
                name: "ReminderInvitationMember",
                schema: "task");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "SupervisorRequest");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "IntegrationOrderLocation",
                schema: "INTG");

            migrationBuilder.DropTable(
                name: "IntegrationOrderProgress",
                schema: "INTG");

            migrationBuilder.DropTable(
                name: "IsolatorStaffAllocation",
                schema: "ISO");

            migrationBuilder.DropTable(
                name: "IsolatorProcedure",
                schema: "ISO");

            migrationBuilder.DropTable(
                name: "Pregnancy",
                schema: "PREG");

            migrationBuilder.DropTable(
                name: "ReminderInvitation",
                schema: "task");

            migrationBuilder.DropTable(
                name: "ReminderProgress",
                schema: "task");

            migrationBuilder.DropTable(
                name: "Trusts",
                schema: "trusts");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "IntegrationOrder",
                schema: "INTG");

            migrationBuilder.DropTable(
                name: "SupervisorRequestType");

            migrationBuilder.DropTable(
                name: "Isolator",
                schema: "ISO");

            migrationBuilder.DropTable(
                name: "IsolatorShift",
                schema: "ISO");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Reminder",
                schema: "task");

            migrationBuilder.DropTable(
                name: "ReminderProgressStatus",
                schema: "task");

            migrationBuilder.DropTable(
                name: "IntegratedSystem",
                schema: "INTG");

            migrationBuilder.DropTable(
                name: "IntegrationOrderClassification",
                schema: "INTG");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AddressType");
        }
    }
}
