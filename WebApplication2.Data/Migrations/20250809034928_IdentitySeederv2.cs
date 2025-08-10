using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.AspNetCore.Identity;

#nullable disable
namespace WebApplication2.Data.Migrations   // ← AJUSTA si tu namespace es otro
{
    public partial class IdentitySeederv2 : Migration
    {
        // Usa GUIDs fijos para poder revertir en Down()
        private const string AdminRoleId = "11111111-1111-1111-1111-111111111111";
        private const string UserRoleId = "22222222-2222-2222-2222-222222222222";
        private const string AdminUserId = "33333333-3333-3333-3333-333333333333";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Roles
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[,]
                {
                    { AdminRoleId, "Admin", "ADMIN", Guid.NewGuid().ToString() },
                    { UserRoleId,  "User",  "USER",  Guid.NewGuid().ToString() }
                });

            // Usuario admin (hash con PasswordHasher)
            var hasher = new PasswordHasher<IdentityUser>();
            var admin = new IdentityUser
            {
                Id = AdminUserId,
                UserName = "admin@demo.com",
                Email = "admin@demo.com",
                EmailConfirmed = true
            };
            var passwordHash = hasher.HashPassword(admin, "Admin123$");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[]
                {
                    "Id","UserName","NormalizedUserName","Email","NormalizedEmail",
                    "EmailConfirmed","PasswordHash","SecurityStamp","ConcurrencyStamp",
                    "PhoneNumberConfirmed","TwoFactorEnabled","LockoutEnabled","AccessFailedCount"
                },
                values: new object[]
                {
                    AdminUserId,
                    "admin@demo.com","ADMIN@DEMO.COM","admin@demo.com","ADMIN@DEMO.COM",
                    true, passwordHash, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                    false,false,true,0
                });

            // Unión usuario–rol (sin sub‑query)
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { AdminUserId, AdminRoleId });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { AdminUserId, AdminRoleId });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: AdminUserId);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: AdminRoleId);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: UserRoleId);
        }
    }
}
