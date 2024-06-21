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
                name: "SkillSets",
                columns: table => new
                {
                    SkillSetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSets", x => x.SkillSetId);
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
                        principalColumn: "Id");
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
                        principalColumn: "Id");
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
                        principalColumn: "Id");
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
                        principalColumn: "Id");
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
                name: "SkillCategories",
                columns: table => new
                {
                    SkillCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillSetId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategories", x => x.SkillCategoryId);
                    table.ForeignKey(
                        name: "FK_SkillCategories_SkillSets_SkillSetId",
                        column: x => x.SkillSetId,
                        principalTable: "SkillSets",
                        principalColumn: "SkillSetId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "TherapistSessions",
                columns: table => new
                {
                    TherapistSessionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TherapistId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapistSessions", x => x.TherapistSessionId);
                    table.ForeignKey(
                        name: "FK_TherapistSessions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TherapistSessions_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "TherapistId");
                });

            migrationBuilder.CreateTable(
                name: "SkillLineItems",
                columns: table => new
                {
                    SkillLineItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLineItems", x => x.SkillLineItemId);
                    table.ForeignKey(
                        name: "FK_SkillLineItems_SkillCategories_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "SkillCategories",
                        principalColumn: "SkillCategoryId",
                        onDelete: ReferentialAction.Cascade);
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
                    TherapistSessionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.SlotId);
                    table.ForeignKey(
                        name: "FK_Slots_TherapistSessions_TherapistSessionId",
                        column: x => x.TherapistSessionId,
                        principalTable: "TherapistSessions",
                        principalColumn: "TherapistSessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingItems",
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
                    table.PrimaryKey("PK_BillingItems", x => x.BillingItemId);
                    table.ForeignKey(
                        name: "FK_BillingItems_Billings_BillingId",
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
                name: "ProgramStudentSlots",
                columns: table => new
                {
                    ProgramStudentSlotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProgramStudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SlotId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramStudentSlots", x => x.ProgramStudentSlotId);
                    table.ForeignKey(
                        name: "FK_ProgramStudentSlots_ProgramStudents_ProgramStudentId",
                        column: x => x.ProgramStudentId,
                        principalTable: "ProgramStudents",
                        principalColumn: "ProgramStudentId");
                    table.ForeignKey(
                        name: "FK_ProgramStudentSlots_Slots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "Slots",
                        principalColumn: "SlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    ProgramStudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TherapistId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_ProgramStudents_ProgramStudentId",
                        column: x => x.ProgramStudentId,
                        principalTable: "ProgramStudents",
                        principalColumn: "ProgramStudentId");
                    table.ForeignKey(
                        name: "FK_Reports_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "TherapistId");
                });

            migrationBuilder.CreateTable(
                name: "ReportSkillSets",
                columns: table => new
                {
                    ReportSkillSetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkillSetId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSkillSets", x => x.ReportSkillSetId);
                    table.ForeignKey(
                        name: "FK_ReportSkillSets_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportSkillSets_SkillSets_SkillSetId",
                        column: x => x.SkillSetId,
                        principalTable: "SkillSets",
                        principalColumn: "SkillSetId");
                });

            migrationBuilder.CreateTable(
                name: "ReportSkillCategories",
                columns: table => new
                {
                    ReportSkillCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkillCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportSkillSetId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSkillCategories", x => x.ReportSkillCategoryId);
                    table.ForeignKey(
                        name: "FK_ReportSkillCategories_ReportSkillSets_ReportSkillSetId",
                        column: x => x.ReportSkillSetId,
                        principalTable: "ReportSkillSets",
                        principalColumn: "ReportSkillSetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportSkillCategories_SkillCategories_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "SkillCategories",
                        principalColumn: "SkillCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "ReportSkillLineItems",
                columns: table => new
                {
                    ReportSkillLineItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SkillLineItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportSkillCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSkillLineItems", x => x.ReportSkillLineItemId);
                    table.ForeignKey(
                        name: "FK_ReportSkillLineItems_ReportSkillCategories_ReportSkillCategoryId",
                        column: x => x.ReportSkillCategoryId,
                        principalTable: "ReportSkillCategories",
                        principalColumn: "ReportSkillCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportSkillLineItems_SkillLineItems_SkillLineItemId",
                        column: x => x.SkillLineItemId,
                        principalTable: "SkillLineItems",
                        principalColumn: "SkillLineItemId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32c96e9f-e211-44f7-9857-b0fa5ab21fa9", null, "Therapist", "THERAPIST" },
                    { "4525b39f-fa96-409c-8713-3060af5c5c4f", null, "Parent", "PARENT" },
                    { "56ed7175-71ad-491e-a823-2fcd613ebadd", null, "CustomerService", "CUSTOMERSERVICE" },
                    { "9cf2591a-1bba-4e4f-8c8a-65a8934886f6", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user1", 0, "28a57ed8-e1b5-454d-a846-9e581ecb6e12", "admin1@example.com", false, false, null, "ADMIN1@EXAMPLE.COM", "ADMIN1", "AQAAAAIAAYagAAAAENaPtaKlvasjBGOSagexVF7YEgAEKUFzuEf/LDzT+7JolU+xUpOGq5Z8yvVBXa+Obg==", null, false, "d44f6838-0d17-4a6c-91e4-97e60ed9be07", false, "admin1" },
                    { "user2", 0, "6755df9d-ebce-433b-84d0-efa573da734a", "therapist1@example.com", false, false, null, "THERAPIST1@EXAMPLE.COM", "THERAPIST1", "AQAAAAIAAYagAAAAEHDunkbIjtXRopYT8ItvBXU5+iVVM6kbTdhmfKlnaNOuSIhZ+ZsPXb2+bqpixDajrQ==", null, false, "aa9f612f-3796-45a2-bf46-7062c1f69dae", false, "therapist1" },
                    { "user3", 0, "676d77f6-933f-45b4-9419-f5c9f7f770de", "customerService1@example.com", false, false, null, "CUSTOMERSERVICE1@EXAMPLE.COM", "CUSTOMERSERVICE1", "AQAAAAIAAYagAAAAEKZTl9GU2XwLuCSiCt+HP+79QW8YvNcf208KNOalK9k2JCA8ryl5mOZOnlQ/Du+gBQ==", null, false, "75fde260-f476-4378-8463-137b40e3db77", false, "customerService1" },
                    { "user4", 0, "2e1f85a6-a8ed-4b43-9733-0978c63ced08", "parent1@example.com", false, false, null, "PARENT1@EXAMPLE.COM", "PARENT1", "AQAAAAIAAYagAAAAEE521VuStGhARCU1sYyO88Wav0Q0i+fTg/9wu6nKvTafZNMf2jupnl7jyDMZpmIwmw==", null, false, "229ebe10-3348-49fa-bc78-bd0c6c85ec83", false, "parent1" }
                });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "BillingId", "IssueDate", "PaymentDate", "PaymentId", "PaymentStatus", "ProgramId", "ProgramStudentId", "StudentId", "TotalPayAmount" },
                values: new object[] { "billing1", new DateTime(2024, 6, 21, 13, 2, 36, 993, DateTimeKind.Local).AddTicks(3491), null, null, false, null, "programStudent1", null, 200.0m });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramId", "Description", "Name", "Objective", "Price" },
                values: new object[] { "program1", "Description One", "Program One", "Objective One", 100.0m });

            migrationBuilder.InsertData(
                table: "SkillSets",
                columns: new[] { "SkillSetId", "Description", "Name" },
                values: new object[,]
                {
                    { "1", "", "S-Subjective Assesment" },
                    { "2", "O-Objective Assesment", "Motor & Praxis Skills" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "AppUserId", "Name" },
                values: new object[] { "admin1", "user1", "Admin One" });

            migrationBuilder.InsertData(
                table: "BillingItems",
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
                table: "SkillCategories",
                columns: new[] { "SkillCategoryId", "Name", "SkillSetId" },
                values: new object[,]
                {
                    { "1.1", "Observation", "1" },
                    { "2.1", "Main", "2" },
                    { "2.2", "Gross Motor Function", "2" },
                    { "2.3", "Fine Motor Function", "2" }
                });

            migrationBuilder.InsertData(
                table: "Therapists",
                columns: new[] { "TherapistId", "AppUserId", "Name" },
                values: new object[] { "therapist1", "user2", "Therapist One" });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "AnnouncementId", "AdminId", "Content", "Date", "Status", "Title" },
                values: new object[] { "announcement1", "admin1", "Content of Announcement One", new DateTime(2024, 6, 21, 13, 2, 36, 993, DateTimeKind.Local).AddTicks(4441), true, "Announcement One" });

            migrationBuilder.InsertData(
                table: "SkillLineItems",
                columns: new[] { "SkillLineItemId", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { "1.1.a", "Enter: by his/ her self", "1.1" },
                    { "1.1.b", "With Prompting", "1.1" },
                    { "1.1.c", "Difficuties separate with parents", "1.1" },
                    { "1.1.d", "With Crying and Refuse", "1.1" },
                    { "2.1.a", "Range Of Motion (Upper/ lower/ extrem)", "2.1" },
                    { "2.1.b", "Muscle Tone", "2.1" },
                    { "2.1.c", "Muscle Strength", "2.1" },
                    { "2.2.a", "Standing", "2.2" },
                    { "2.2.b", "Crawling", "2.2" },
                    { "2.2.c", "Walking", "2.2" },
                    { "2.3.a", "Grasp & Release", "2.3" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "DOB", "Gender", "Name", "ParentId" },
                values: new object[] { "student1", 10, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Student One", "parent1" });

            migrationBuilder.InsertData(
                table: "TherapistSessions",
                columns: new[] { "TherapistSessionId", "SessionId", "TherapistId" },
                values: new object[] { "therapistSession1", "session1", "therapist1" });

            migrationBuilder.InsertData(
                table: "ProgramStudents",
                columns: new[] { "ProgramStudentId", "ProgramId", "RegisterDate", "StudentId" },
                values: new object[] { "programStudent1", "program1", new DateTime(2024, 6, 21, 13, 2, 36, 993, DateTimeKind.Local).AddTicks(2572), "student1" });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "SlotId", "EndTime", "StartTime", "TherapistSessionId" },
                values: new object[] { "slot1", new DateTime(2024, 6, 21, 15, 2, 36, 993, DateTimeKind.Local).AddTicks(3149), new DateTime(2024, 6, 21, 14, 2, 36, 993, DateTimeKind.Local).AddTicks(3134), "therapistSession1" });

            migrationBuilder.InsertData(
                table: "ProgramStudentSlots",
                columns: new[] { "ProgramStudentSlotId", "ProgramStudentId", "SlotId" },
                values: new object[] { "ProgramStudentSlot1", "programStudent1", "slot1" });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "Category", "Content", "ProgramStudentId", "TherapistId" },
                values: new object[] { "report1", 0, "Content of Report One", "programStudent1", "therapist1" });

            migrationBuilder.InsertData(
                table: "ReportSkillSets",
                columns: new[] { "ReportSkillSetId", "Comment", "ReportId", "SkillSetId" },
                values: new object[,]
                {
                    { "r1", "Halo world", "report1", "1" },
                    { "r2", "Halo world", "report1", "2" }
                });

            migrationBuilder.InsertData(
                table: "ReportSkillCategories",
                columns: new[] { "ReportSkillCategoryId", "ReportSkillSetId", "SkillCategoryId" },
                values: new object[,]
                {
                    { "r11", "r1", "1.1" },
                    { "r21", "r2", "2.1" },
                    { "r22", "r2", "2.2" },
                    { "r23", "r2", "2.3" }
                });

            migrationBuilder.InsertData(
                table: "ReportSkillLineItems",
                columns: new[] { "ReportSkillLineItemId", "Comment", "ReportSkillCategoryId", "SkillLineItemId", "Status" },
                values: new object[,]
                {
                    { "r11a", "Halo", "r11", "1.1.a", true },
                    { "r11b", "Halo", "r11", "1.1.b", true },
                    { "r11c", "Halo", "r11", "1.1.c", false },
                    { "r11d", "Halo", "r11", "1.1.d", true },
                    { "r21a", "Halo", "r21", "2.1.a", true },
                    { "r21b", "Halo", "r21", "2.1.b", false },
                    { "r21c", "Halo", "r21", "2.1.c", false },
                    { "r22a", "Halo", "r22", "2.2.a", true },
                    { "r22b", "Halo", "r22", "2.2.b", true },
                    { "r22c", "Halo", "r22", "2.2.c", true },
                    { "r23a", "Halo", "r23", "2.3.a", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins",
                column: "AppUserId",
                unique: true);

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
                name: "IX_BillingItems_BillingId",
                table: "BillingItems",
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
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_AppUserId",
                table: "Parents",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramStudents_ProgramId",
                table: "ProgramStudents",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramStudents_StudentId",
                table: "ProgramStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramStudentSlots_ProgramStudentId",
                table: "ProgramStudentSlots",
                column: "ProgramStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramStudentSlots_SlotId",
                table: "ProgramStudentSlots",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ProgramStudentId",
                table: "Reports",
                column: "ProgramStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_TherapistId",
                table: "Reports",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSkillCategories_ReportSkillSetId_ReportSkillCategoryId",
                table: "ReportSkillCategories",
                columns: new[] { "ReportSkillSetId", "ReportSkillCategoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportSkillCategories_SkillCategoryId",
                table: "ReportSkillCategories",
                column: "SkillCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSkillLineItems_ReportSkillCategoryId_ReportSkillLineItemId",
                table: "ReportSkillLineItems",
                columns: new[] { "ReportSkillCategoryId", "ReportSkillLineItemId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportSkillLineItems_SkillLineItemId",
                table: "ReportSkillLineItems",
                column: "SkillLineItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSkillSets_ReportId_SkillSetId",
                table: "ReportSkillSets",
                columns: new[] { "ReportId", "SkillSetId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportSkillSets_SkillSetId",
                table: "ReportSkillSets",
                column: "SkillSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ProgramId",
                table: "Sessions",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillCategories_SkillSetId",
                table: "SkillCategories",
                column: "SkillSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillLineItems_SkillCategoryId",
                table: "SkillLineItems",
                column: "SkillCategoryId");

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
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TherapistSessions_SessionId",
                table: "TherapistSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistSessions_TherapistId_SessionId",
                table: "TherapistSessions",
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
                name: "BillingItems");

            migrationBuilder.DropTable(
                name: "CustomerServices");

            migrationBuilder.DropTable(
                name: "ProgramStudentSlots");

            migrationBuilder.DropTable(
                name: "ReportSkillLineItems");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "ReportSkillCategories");

            migrationBuilder.DropTable(
                name: "SkillLineItems");

            migrationBuilder.DropTable(
                name: "TherapistSessions");

            migrationBuilder.DropTable(
                name: "ReportSkillSets");

            migrationBuilder.DropTable(
                name: "SkillCategories");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "SkillSets");

            migrationBuilder.DropTable(
                name: "ProgramStudents");

            migrationBuilder.DropTable(
                name: "Therapists");

            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
