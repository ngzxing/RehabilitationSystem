using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RehabilitationSystem.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32c96e9f-e211-44f7-9857-b0fa5ab21fa9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4525b39f-fa96-409c-8713-3060af5c5c4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56ed7175-71ad-491e-a823-2fcd613ebadd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cf2591a-1bba-4e4f-8c8a-65a8934886f6");

            migrationBuilder.AddColumn<int>(
                name: "CurrentProgramStudent",
                table: "Slots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxProgramStudent",
                table: "Slots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentSessions",
                table: "Programs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxSessions",
                table: "Programs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "AnnouncementId",
                keyValue: "announcement1",
                column: "Date",
                value: new DateTime(2024, 6, 21, 15, 53, 14, 454, DateTimeKind.Local).AddTicks(8708));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3afc2af3-4cc3-4636-96f8-9ed0b9864532", null, "Parent", "PARENT" },
                    { "62b7a44b-af6d-40fb-a026-d9f8bb5c9ea1", null, "Admin", "ADMIN" },
                    { "8bff05dd-c856-4030-b863-adbbb472418c", null, "CustomerService", "CUSTOMERSERVICE" },
                    { "ac2bac57-4715-45bb-96d6-bf3d0c95db31", null, "Therapist", "THERAPIST" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e69d44a6-75af-4559-b550-88001200179f", "AQAAAAIAAYagAAAAEHPhMjdtzms/ZKrbpy6LzbAQX6K0IWne0IFjesPRu03Uby5VntspivDPvd9EHeXC2Q==", "cc92e4e5-6265-44b9-b47c-6f0df620c274" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1d0ea4e-32c4-4c7b-930b-a04513b85e76", "AQAAAAIAAYagAAAAEHAfznyAkg+qlrE8lUjT8tLFqdz5u42I6rwKIQTmoqDow3t/Dj3LsBpQzhuACogpmA==", "abe298b2-2b10-49c1-b0b9-33be9501c7aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b81abc43-79ee-48fe-bf09-2ebca3402675", "AQAAAAIAAYagAAAAEOgq//C3x72MolPcYVAOIYa9mJBLcof/CM1C9qpXEYZuSKWFf97/J38CL1IU+dIUOw==", "b8169682-585a-47e7-bcb7-8d2f13c56077" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3709b7e-f93d-4df3-8c88-f2fdf01059d3", "AQAAAAIAAYagAAAAELUtYTPtSplGvmzUuVm9tsZRw0FAEi3g0jrNBSVLZT1PVUm1pXlPjSpbhg6Lx8Ck3A==", "1c342cdf-756a-4b38-b617-a46eb104dd4b" });

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "BillingId",
                keyValue: "billing1",
                column: "IssueDate",
                value: new DateTime(2024, 6, 21, 15, 53, 14, 454, DateTimeKind.Local).AddTicks(7779));

            migrationBuilder.UpdateData(
                table: "ProgramStudents",
                keyColumn: "ProgramStudentId",
                keyValue: "programStudent1",
                column: "RegisterDate",
                value: new DateTime(2024, 6, 21, 15, 53, 14, 454, DateTimeKind.Local).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: "program1",
                columns: new[] { "CurrentSessions", "MaxSessions" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: "slot1",
                columns: new[] { "CurrentProgramStudent", "EndTime", "MaxProgramStudent", "StartTime" },
                values: new object[] { 1, new DateTime(2024, 6, 21, 17, 53, 14, 454, DateTimeKind.Local).AddTicks(7441), 10, new DateTime(2024, 6, 21, 16, 53, 14, 454, DateTimeKind.Local).AddTicks(7423) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3afc2af3-4cc3-4636-96f8-9ed0b9864532");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b7a44b-af6d-40fb-a026-d9f8bb5c9ea1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bff05dd-c856-4030-b863-adbbb472418c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac2bac57-4715-45bb-96d6-bf3d0c95db31");

            migrationBuilder.DropColumn(
                name: "CurrentProgramStudent",
                table: "Slots");

            migrationBuilder.DropColumn(
                name: "MaxProgramStudent",
                table: "Slots");

            migrationBuilder.DropColumn(
                name: "CurrentSessions",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "MaxSessions",
                table: "Programs");

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "AnnouncementId",
                keyValue: "announcement1",
                column: "Date",
                value: new DateTime(2024, 6, 21, 13, 2, 36, 993, DateTimeKind.Local).AddTicks(4441));

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28a57ed8-e1b5-454d-a846-9e581ecb6e12", "AQAAAAIAAYagAAAAENaPtaKlvasjBGOSagexVF7YEgAEKUFzuEf/LDzT+7JolU+xUpOGq5Z8yvVBXa+Obg==", "d44f6838-0d17-4a6c-91e4-97e60ed9be07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6755df9d-ebce-433b-84d0-efa573da734a", "AQAAAAIAAYagAAAAEHDunkbIjtXRopYT8ItvBXU5+iVVM6kbTdhmfKlnaNOuSIhZ+ZsPXb2+bqpixDajrQ==", "aa9f612f-3796-45a2-bf46-7062c1f69dae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "676d77f6-933f-45b4-9419-f5c9f7f770de", "AQAAAAIAAYagAAAAEKZTl9GU2XwLuCSiCt+HP+79QW8YvNcf208KNOalK9k2JCA8ryl5mOZOnlQ/Du+gBQ==", "75fde260-f476-4378-8463-137b40e3db77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e1f85a6-a8ed-4b43-9733-0978c63ced08", "AQAAAAIAAYagAAAAEE521VuStGhARCU1sYyO88Wav0Q0i+fTg/9wu6nKvTafZNMf2jupnl7jyDMZpmIwmw==", "229ebe10-3348-49fa-bc78-bd0c6c85ec83" });

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "BillingId",
                keyValue: "billing1",
                column: "IssueDate",
                value: new DateTime(2024, 6, 21, 13, 2, 36, 993, DateTimeKind.Local).AddTicks(3491));

            migrationBuilder.UpdateData(
                table: "ProgramStudents",
                keyColumn: "ProgramStudentId",
                keyValue: "programStudent1",
                column: "RegisterDate",
                value: new DateTime(2024, 6, 21, 13, 2, 36, 993, DateTimeKind.Local).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "SlotId",
                keyValue: "slot1",
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 2, 36, 993, DateTimeKind.Local).AddTicks(3149), new DateTime(2024, 6, 21, 14, 2, 36, 993, DateTimeKind.Local).AddTicks(3134) });
        }
    }
}
