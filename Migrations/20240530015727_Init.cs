using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RehabilitationSystem.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objective = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerServices",
                columns: table => new
                {
                    CustomerServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerServices", x => x.CustomerServiceId);
                    table.ForeignKey(
                        name: "FK_CustomerServices_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentId);
                    table.ForeignKey(
                        name: "FK_Parents_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Therapists",
                columns: table => new
                {
                    TherapistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.TherapistId);
                    table.ForeignKey(
                        name: "FK_Therapists_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Sessions_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "ProgramId");
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    AnnouncementId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.AnnouncementId);
                    table.ForeignKey(
                        name: "FK_Announcements_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "ParentId");
                });

            migrationBuilder.CreateTable(
                name: "TherapistSession",
                columns: table => new
                {
                    TherapistSessionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TherapistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapistSession", x => x.TherapistSessionId);
                    table.ForeignKey(
                        name: "FK_TherapistSession_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TherapistSession_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "TherapistId");
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    BillingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPayAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramStudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProgramId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.BillingId);
                    table.UniqueConstraint("AK_Billings_ProgramStudentId", x => x.ProgramStudentId);
                    table.ForeignKey(
                        name: "FK_Billings_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "ProgramId");
                    table.ForeignKey(
                        name: "FK_Billings_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    SlotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TherapistSessionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.SlotId);
                    table.ForeignKey(
                        name: "FK_Slots_TherapistSession_TherapistSessionId",
                        column: x => x.TherapistSessionId,
                        principalTable: "TherapistSession",
                        principalColumn: "TherapistSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingItem",
                columns: table => new
                {
                    BillingItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BillingId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingItem", x => x.BillingItemId);
                    table.ForeignKey(
                        name: "FK_BillingItem_Billings_BillingId",
                        column: x => x.BillingId,
                        principalTable: "Billings",
                        principalColumn: "BillingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramStudents",
                columns: table => new
                {
                    ProgramStudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgramId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramStudents", x => x.ProgramStudentId);
                    table.ForeignKey(
                        name: "FK_ProgramStudents_Billings_ProgramStudentId",
                        column: x => x.ProgramStudentId,
                        principalTable: "Billings",
                        principalColumn: "ProgramStudentId");
                    table.ForeignKey(
                        name: "FK_ProgramStudents_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "ProgramId");
                    table.ForeignKey(
                        name: "FK_ProgramStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "ProgramStudentSlot",
                columns: table => new
                {
                    ProgramStudentSlotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProgramStudentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SlotId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramStudentSlot", x => x.ProgramStudentSlotId);
                    table.ForeignKey(
                        name: "FK_ProgramStudentSlot_ProgramStudents_ProgramStudentId",
                        column: x => x.ProgramStudentId,
                        principalTable: "ProgramStudents",
                        principalColumn: "ProgramStudentId");
                    table.ForeignKey(
                        name: "FK_ProgramStudentSlot_Slots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "Slots",
                        principalColumn: "SlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramStudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TherapistId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Report_ProgramStudents_ProgramStudentId",
                        column: x => x.ProgramStudentId,
                        principalTable: "ProgramStudents",
                        principalColumn: "ProgramStudentId");
                    table.ForeignKey(
                        name: "FK_Report_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "TherapistId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21fdc479-afee-4e09-a471-dd8a0631e6cc", null, "Therapist", "THERAPIST" },
                    { "35191751-2291-41e2-863b-25ec644c7ecc", null, "CustomerService", "CUSTOMERSERVICE" },
                    { "4e7ef3dd-d9c2-4c6a-982e-9230dc975000", null, "Parent", "PARENT" },
                    { "5a7f1b08-41fe-4481-9fd2-3bf358695f26", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user1", 0, "f3e0d7ce-c005-4e08-b3b7-cde37a7aa872", "admin1@example.com", false, false, null, "ADMIN1@EXAMPLE.COM", "ADMIN1", "AQAAAAIAAYagAAAAEDr+TF0mdnmyKJ53MHT+pT0uMgiKcILHNENt5byZxwhmxUX5guqrAgANtSNYk11whw==", null, false, "7c73e058-a872-4f74-8113-d89c13b0d943", false, "admin1" },
                    { "user2", 0, "1630e5c0-a052-4d30-8a9a-78cb412e13f4", "therapist1@example.com", false, false, null, "THERAPIST1@EXAMPLE.COM", "THERAPIST1", "AQAAAAIAAYagAAAAEAw3itUexneTcWo1/SD4g39PoYBjBxgiHX7bGH7Nn9IncnEPL0rQDaSBzRLyNvtZqA==", null, false, "31d8d600-5fec-4789-bfd0-ac0e28362fdb", false, "therapist1" },
                    { "user3", 0, "aff279d7-b80b-4899-8db7-c04dc3e3476c", "customerService1@example.com", false, false, null, "CUSTOMERSERVICE1@EXAMPLE.COM", "CUSTOMERSERVICE1", "AQAAAAIAAYagAAAAEIIbe+8JkgGqP+F4VL4oAYk3dtJitlsHNEEUL6+yh1JJUXC45WZTKs86ybVjIPLRDg==", null, false, "a768d9a9-06fb-4997-803f-defbdb62e673", false, "customerService1" },
                    { "user4", 0, "3b69883b-b4b2-4f2b-877b-b14abc545b60", "parent1@example.com", false, false, null, "PARENT1@EXAMPLE.COM", "PARENT1", "AQAAAAIAAYagAAAAEOO8Civ+9f8TPKdfge8srC9Z8/kd7qT7+W+6PbAS+3UREJf1fzFGRjTVzmsGbTYH5w==", null, false, "079f0203-4e74-4b04-bc78-040df9a1c2ac", false, "parent1" }
                });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "BillingId", "IssueDate", "PaymentDate", "PaymentId", "PaymentStatus", "ProgramId", "ProgramStudentId", "StudentId", "TotalPayAmount" },
                values: new object[] { "billing1", new DateTime(2024, 5, 30, 9, 57, 25, 138, DateTimeKind.Local).AddTicks(3508), null, null, false, null, "programStudent1", null, 200.0m });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramId", "Description", "Name", "Objective", "Price" },
                values: new object[] { "program1", "Description One", "Program One", "Objective One", 100.0m });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "AppUserId", "Name" },
                values: new object[] { "admin1", "user1", "Admin One" });

            migrationBuilder.InsertData(
                table: "BillingItem",
                columns: new[] { "BillingItemId", "Amount", "BillingId", "Description", "Price" },
                values: new object[] { "billingItem1", 4, "billing1", "Billing Item One", 50.0m });

            migrationBuilder.InsertData(
                table: "CustomerServices",
                columns: new[] { "CustomerServiceId", "AppUserId", "Name" },
                values: new object[] { "customerService1", "user3", "Customer Service One" });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ParentId", "Address", "AppUserId", "City", "Name", "Occupation", "Postcode", "State" },
                values: new object[] { "parent1", "123 Street", "user4", "City", "Parent One", "Occupation", "12345", "State" });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "Description", "Name", "ProgramId" },
                values: new object[] { "session1", "Description One", "Session One", "program1" });

            migrationBuilder.InsertData(
                table: "Therapists",
                columns: new[] { "TherapistId", "AppUserId", "Name" },
                values: new object[] { "therapist1", "user2", "Therapist One" });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "AnnouncementId", "AdminId", "Content", "Date", "Status", "Title" },
                values: new object[] { "announcement1", "admin1", "Content of Announcement One", new DateTime(2024, 5, 30, 9, 57, 25, 138, DateTimeKind.Local).AddTicks(4462), true, "Announcement One" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "DOB", "Gender", "Name", "ParentId" },
                values: new object[] { "student1", 10, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Student One", "parent1" });

            migrationBuilder.InsertData(
                table: "TherapistSession",
                columns: new[] { "TherapistSessionId", "SessionId", "TherapistId" },
                values: new object[] { "therapistSession1", "session1", "therapist1" });

            migrationBuilder.InsertData(
                table: "ProgramStudents",
                columns: new[] { "ProgramStudentId", "ProgramId", "RegisterDate", "StudentId" },
                values: new object[] { "programStudent1", "program1", new DateTime(2024, 5, 30, 9, 57, 25, 138, DateTimeKind.Local).AddTicks(2654), "student1" });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "SlotId", "Date", "EndTime", "StartTime", "TherapistSessionId" },
                values: new object[] { "slot1", new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 30, 11, 57, 25, 138, DateTimeKind.Local).AddTicks(3171), new DateTime(2024, 5, 30, 10, 57, 25, 138, DateTimeKind.Local).AddTicks(3031), "therapistSession1" });

            migrationBuilder.InsertData(
                table: "ProgramStudentSlot",
                columns: new[] { "ProgramStudentSlotId", "ProgramStudentId", "SlotId" },
                values: new object[] { "ProgramStudentSlot1", "programStudent1", "slot1" });

            migrationBuilder.InsertData(
                table: "Report",
                columns: new[] { "ReportId", "Content", "ProgramStudentId", "TherapistId", "Title" },
                values: new object[] { "report1", "Content of Report One", "programStudent1", "therapist1", "Report One" });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AdminId",
                table: "Announcements",
                column: "AdminId");

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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BillingItem_BillingId",
                table: "BillingItem",
                column: "BillingId");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_ProgramId",
                table: "Billings",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_StudentId",
                table: "Billings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerServices_AppUserId",
                table: "CustomerServices",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_AppUserId",
                table: "Parents",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramStudents_ProgramId",
                table: "ProgramStudents",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramStudents_StudentId",
                table: "ProgramStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramStudentSlot_ProgramStudentId",
                table: "ProgramStudentSlot",
                column: "ProgramStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramStudentSlot_SlotId",
                table: "ProgramStudentSlot",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ProgramStudentId_TherapistId",
                table: "Report",
                columns: new[] { "ProgramStudentId", "TherapistId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Report_TherapistId",
                table: "Report",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ProgramId",
                table: "Sessions",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_TherapistSessionId",
                table: "Slots",
                column: "TherapistSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ParentId",
                table: "Students",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapists_AppUserId",
                table: "Therapists",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistSession_SessionId",
                table: "TherapistSession",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistSession_TherapistId_SessionId",
                table: "TherapistSession",
                columns: new[] { "TherapistId", "SessionId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

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
                name: "BillingItem");

            migrationBuilder.DropTable(
                name: "CustomerServices");

            migrationBuilder.DropTable(
                name: "ProgramStudentSlot");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "ProgramStudents");

            migrationBuilder.DropTable(
                name: "TherapistSession");

            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Therapists");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
