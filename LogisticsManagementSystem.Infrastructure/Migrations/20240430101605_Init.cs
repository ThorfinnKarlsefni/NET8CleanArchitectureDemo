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
                    Path = table.Column<string>(type: "varchar(256)", nullable: false),
                    Icon = table.Column<string>(type: "varchar(256)", nullable: true),
                    Component = table.Column<string>(type: "varchar(256)", nullable: true),
                    Sort = table.Column<int>(type: "integer", nullable: false),
                    Visibility = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
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
                    Path = table.Column<string>(type: "varchar(256)", nullable: true),
                    Action = table.Column<string>(type: "varchar(256)", nullable: true),
                    Method = table.Column<string>(type: "varchar(256)", nullable: true),
                    Sort = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
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
                    Slug = table.Column<string>(type: "varchar(256)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
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
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Avatar = table.Column<string>(type: "varchar(256)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    TokenVersion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
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
                name: "MenuRole",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRole", x => new { x.MenuId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_MenuRole_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Component", "CreatedAt", "DeletedAt", "Icon", "Name", "ParentId", "Path", "Sort", "UpdatedAt", "Visibility" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9840), null, "", "系统", null, "/admin", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9840), true },
                    { 2, "./Admin/Users", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9850), null, "", "员工列表", 1, "/admin/users", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9850), true },
                    { 3, "./Admin/Menus", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9850), null, "", "菜单管理", 1, "/admin/menus", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9850), true },
                    { 4, "./Admin/Permissions", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9850), null, "", "权限管理", 1, "/admin/permissions", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9850), true },
                    { 5, "./Admin/Roles", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9850), null, "", "角色管理", 1, "/admin/roles", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9850), true }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "Controller", "CreatedAt", "DeletedAt", "Method", "Name", "ParentId", "Path", "Sort", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9870), null, null, "系统", null, null, 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9870) },
                    { 2, null, "Menu", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9880), null, null, "菜单管理", 1, "", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9880) },
                    { 3, null, "Menu", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9880), null, "GET", "查看", 2, "api/auth/menu", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9880) },
                    { 4, null, "Menu", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9880), null, "CREATE", "创建", 2, "api/auth/menu", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9880) },
                    { 5, null, "Menu", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9880), null, "UPDATE", "修改", 2, "api/auth/menu/{id}", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9880) },
                    { 6, null, "Menu", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890), null, "DELETE", "删除", 2, "api/auth/menu/{id}", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890) },
                    { 7, null, "Permission", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890), null, null, "权限管理", 1, "", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890) },
                    { 8, null, "Permission", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890), null, "GET", "查看", 7, "api/auth/permission", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890) },
                    { 9, null, "Permission", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890), null, "CREATE", "创建", 7, "api/auth/permission", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890) },
                    { 10, null, "Permission", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890), null, "UPDATE", "修改", 7, "api/auth/permission/{id}", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890) },
                    { 11, null, "Permission", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890), null, "DELETE", "删除", 7, "api/auth/permission/{id}", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890) },
                    { 12, null, "Role", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890), null, null, "角色管理", 1, "", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9890) },
                    { 13, null, "Role", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9900), null, "GET", "查看", 12, "api/auth/roles", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9900) },
                    { 14, null, "Role", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9900), null, "CREATE", "创建", 12, "api/auth/role", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9900) },
                    { 15, null, "Role", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9900), null, "UPDATE", "修改", 12, "api/auth/role/{id}", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9900) },
                    { 16, null, "Role", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9900), null, "DELETE", "删除", 12, "api/auth/role/{id}", 0, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9900) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Name", "NormalizedName", "Slug", "UpdatedAt" },
                values: new object[] { new Guid("10bd099e-9753-4962-b4e8-9ecb6965677a"), null, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9810), null, "Admin", "ADMIN", null, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9810) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "CompanyId", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("b1882f2a-2473-413c-9563-ac900741c8f0"), 0, "http://124.222.5.145/avatar/ogrwRJqXMXSGHuGIC3JQ52HOdLpyME.avif", null, "6bcef967-c50a-4573-8575-4f7e75a6c426", new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9690), null, "402832626@qq.com", false, true, null, "Cheung", null, "CHEUNG", "AQAAAAIAAYagAAAAEMSuTV5vdkw0LBQICgUF2Rl25Yu9TiFhrhatAn9JCyrSnMe/tjJRRdXj/nkltAGwiQ==", "", false, "373BQTFYVCP7RJ3VEPFAOSDBMBDQIEH4", false, new DateTime(2024, 4, 30, 18, 16, 5, 395, DateTimeKind.Local).AddTicks(9720), "Cheung" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("10bd099e-9753-4962-b4e8-9ecb6965677a"), new Guid("b1882f2a-2473-413c-9563-ac900741c8f0") });

            migrationBuilder.CreateIndex(
                name: "IX_MenuRole_RoleId",
                table: "MenuRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuRole");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
