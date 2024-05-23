using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticsManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Controller = table.Column<string>(type: "varchar(256)", nullable: true),
                    Path = table.Column<string>(type: "varchar(256)", nullable: false),
                    Icon = table.Column<string>(type: "varchar(256)", nullable: true),
                    Component = table.Column<string>(type: "varchar(256)", nullable: true),
                    Sort = table.Column<int>(type: "integer", nullable: false),
                    Visibility = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Controller = table.Column<string>(type: "varchar(256)", nullable: true),
                    Action = table.Column<string>(type: "varchar(256)", nullable: true),
                    Method = table.Column<string>(type: "varchar(256)", nullable: true),
                    Sort = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NormalizedName = table.Column<string>(type: "varchar(256)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(256)", nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", nullable: true),
                    Avatar = table.Column<string>(type: "varchar(256)", nullable: true),
                    PasswordHash = table.Column<string>(type: "varchar(256)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "varchar(256)", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTime>(type: "timestamp", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleMenus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenus", x => new { x.MenuId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleMenus_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.PermissionId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Component", "Controller", "CreatedAt", "DeletedAt", "Icon", "IsDeleted", "Name", "ParentId", "Path", "Sort", "UpdatedAt", "Visibility" },
                values: new object[,]
                {
                    { 1, "", "", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5630), null, "", false, "系统", null, "/admin", 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5630), true },
                    { 2, "./Admin/Menus", "Menu", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5630), null, "", false, "菜单管理", 1, "/admin/menus", 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5630), true },
                    { 3, "./Admin/Permissions", "Permission", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5630), null, "", false, "权限管理", 1, "/admin/permissions", 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5630), true },
                    { 4, "./Admin/Roles", "Role", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5640), null, "", false, "角色管理", 1, "/admin/roles", 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5640), true },
                    { 5, "./Admin/Users", "User", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5640), null, "", false, "员工列表", 1, "/admin/users", 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5640), true }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "Controller", "CreatedAt", "DeletedAt", "IsDeleted", "Method", "Name", "ParentId", "Sort", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5660), null, false, null, "系统", null, 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5660) },
                    { 2, null, "Role", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5660), null, false, null, "角色管理", 1, 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5660) },
                    { 3, "role:get", "Role", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5670), null, false, "GET", "查看", 2, 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5670) },
                    { 4, "role:create", "Role", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5670), null, false, "CREATE", "创建", 2, 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5670) },
                    { 5, "role:update", "Role", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5670), null, false, "UPDATE", "修改", 2, 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5670) },
                    { 6, "role:delete", "Role", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5670), null, false, "DELETE", "删除", 2, 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5670) },
                    { 7, null, "User", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5670), null, false, null, "员工管理", 1, 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5670) },
                    { 8, "user:get", "User", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5680), null, false, "GET", "查看", 7, 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5680) },
                    { 9, "user:create", "User", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5680), null, false, "CREATE", "创建", 7, 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5680) },
                    { 10, "user:update", "User", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5680), null, false, "UPDATE", "修改", 7, 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5680) },
                    { 11, "user:delete", "User", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5680), null, false, "DELETE", "删除", 7, 0, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5680) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("c6c2baf4-d34e-4272-8107-82907cffcd30"), new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5560), null, false, "Admin", "ADMIN", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5560) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "CompanyId", "CreatedAt", "DeletedAt", "Email", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("07065f3e-3ac5-45c3-b906-5a44132a740b"), null, null, new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5400), null, "402832626@qq.com", false, true, null, "Cheung", "CHEUNG", "AQAAAAIAAYagAAAAEMSuTV5vdkw0LBQICgUF2Rl25Yu9TiFhrhatAn9JCyrSnMe/tjJRRdXj/nkltAGwiQ==", "15563239095", false, "373BQTFYVCP7RJ3VEPFAOSDBMBDQIEH4", new DateTime(2024, 5, 22, 23, 15, 16, 249, DateTimeKind.Local).AddTicks(5400), "Cheung" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c6c2baf4-d34e-4272-8107-82907cffcd30"), new Guid("07065f3e-3ac5-45c3-b906-5a44132a740b") });

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenus_RoleId",
                table: "RoleMenus",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleMenus");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
