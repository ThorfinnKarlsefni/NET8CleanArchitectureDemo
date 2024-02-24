using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f15580fe-3d74-43be-84bf-d6bcf16c88f4"), new Guid("75576367-f3a9-461e-81a6-59f8d76ef1b9") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f15580fe-3d74-43be-84bf-d6bcf16c88f4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("75576367-f3a9-461e-81a6-59f8d76ef1b9"));

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Users_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Companies_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7990), new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7990) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7990), new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7990) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000), new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000), new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000), new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000), new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000), new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8010), new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(8010) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("f8787e73-d392-4259-a5c8-0f19519d2750"), null, new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7960), null, "Admin", "ADMIN", new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7960) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "CompanyId", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("8fe4b8b7-5723-488d-bdfa-0f0eee91dddb"), 0, "http://avatar.xhwt56.com/ogrwRJqXMXSGHuGIC3JQ52HOdLpyME.avif", null, "6bcef967-c50a-4573-8575-4f7e75a6c426", new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7870), null, "402832626@qq.com", false, true, null, "Cheung", null, "CHEUNG", "AQAAAAIAAYagAAAAEMSuTV5vdkw0LBQICgUF2Rl25Yu9TiFhrhatAn9JCyrSnMe/tjJRRdXj/nkltAGwiQ==", "", false, "373BQTFYVCP7RJ3VEPFAOSDBMBDQIEH4", false, new DateTime(2024, 2, 19, 16, 2, 33, 794, DateTimeKind.Local).AddTicks(7900), "Cheung" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("f8787e73-d392-4259-a5c8-0f19519d2750"), new Guid("8fe4b8b7-5723-488d-bdfa-0f0eee91dddb") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreateUserId",
                table: "Companies",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UpdateUserId",
                table: "Companies",
                column: "UpdateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f8787e73-d392-4259-a5c8-0f19519d2750"), new Guid("8fe4b8b7-5723-488d-bdfa-0f0eee91dddb") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f8787e73-d392-4259-a5c8-0f19519d2750"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8fe4b8b7-5723-488d-bdfa-0f0eee91dddb"));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8980), new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8980) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8980), new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8980) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990), new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990), new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990), new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990), new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990), new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(9000), new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(9000) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("f15580fe-3d74-43be-84bf-d6bcf16c88f4"), null, new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8940), null, "Admin", "ADMIN", new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8940) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "CompanyId", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("75576367-f3a9-461e-81a6-59f8d76ef1b9"), 0, "http://avatar.xhwt56.com/ogrwRJqXMXSGHuGIC3JQ52HOdLpyME.avif", null, "6bcef967-c50a-4573-8575-4f7e75a6c426", new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8830), null, "402832626@qq.com", false, true, null, "Cheung", null, "CHEUNG", "AQAAAAIAAYagAAAAEMSuTV5vdkw0LBQICgUF2Rl25Yu9TiFhrhatAn9JCyrSnMe/tjJRRdXj/nkltAGwiQ==", "", false, "373BQTFYVCP7RJ3VEPFAOSDBMBDQIEH4", false, new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8860), "Cheung" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("f15580fe-3d74-43be-84bf-d6bcf16c88f4"), new Guid("75576367-f3a9-461e-81a6-59f8d76ef1b9") });
        }
    }
}
