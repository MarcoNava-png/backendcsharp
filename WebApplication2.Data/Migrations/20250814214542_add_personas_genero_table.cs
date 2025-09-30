using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_personas_genero_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaterno",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoPaterno",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Personas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PersonaGeneroId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PersonasGenero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasGenero", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PersonaGeneroId",
                table: "Personas",
                column: "PersonaGeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_PersonasGenero_PersonaGeneroId",
                table: "Personas",
                column: "PersonaGeneroId",
                principalTable: "PersonasGenero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_PersonasGenero_PersonaGeneroId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "PersonasGenero");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PersonaGeneroId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "ApellidoPaterno",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PersonaGeneroId",
                table: "Personas");
        }
    }
}
