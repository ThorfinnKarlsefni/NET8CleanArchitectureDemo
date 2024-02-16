using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticsManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuRoles",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "integer", nullable: true),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
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
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    HideMenu = table.Column<bool>(type: "boolean", nullable: false),
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
                    HttpPath = table.Column<string>(type: "varchar(256)", nullable: false),
                    HttpMethod = table.Column<string>(type: "varchar(256)", nullable: false),
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
                columns: new[] { "Id", "Component", "CreatedAt", "DeletedAt", "HideMenu", "Icon", "Name", "ParentId", "Path", "Rank", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8980), null, false, "", "系统", null, "/admin", 0, new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8980) },
                    { 2, "./Admin/Users", new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8980), null, false, "", "员工列表", 1, "/admin/users", 0, new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8980) },
                    { 3, "./Admin/Menu", new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990), null, false, "", "菜单管理", 1, "/admin/menu", 0, new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990) },
                    { 4, "./Admin/Permission", new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990), null, false, "", "权限管理", 1, "/admin/permission", 0, new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990) },
                    { 5, "./Admin/Role", new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990), null, false, "", "角色管理", 1, "/admin/role", 0, new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990) },
                    { 6, "./Admin/Station", new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990), null, false, "", "站点管理", 1, "/admin/station", 0, new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990) },
                    { 7, "", new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990), null, false, "", "运输管理", null, "/transport", 0, new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(8990) },
                    { 8, "./Transport/Invoices", new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(9000), null, false, "", "收货开票", 7, "/transport/invoices", 0, new DateTime(2024, 2, 16, 21, 20, 20, 595, DateTimeKind.Local).AddTicks(9000) }
                });

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
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuRoles");

            migrationBuilder.DropTable(
                name: "Menus");

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
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
