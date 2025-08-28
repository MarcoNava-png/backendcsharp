using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class alter_table_personas_add_fk_usuario_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_UserId",
                table: "Personas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_AspNetUsers_UserId",
                table: "Personas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_AspNetUsers_UserId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_UserId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Personas");
        }
    }
}
