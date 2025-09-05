using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class alter_table_aspirantes_programa_add_fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AspiranteProgramaEstatusId",
                table: "AspirantesProgramas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_PersonaId",
                table: "Estudiantes",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspirantesProgramas_AspiranteProgramaEstatusId",
                table: "AspirantesProgramas",
                column: "AspiranteProgramaEstatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspirantesProgramas_AspirantesProgramasEstatus_AspiranteProgramaEstatusId",
                table: "AspirantesProgramas",
                column: "AspiranteProgramaEstatusId",
                principalTable: "AspirantesProgramasEstatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Personas_PersonaId",
                table: "Estudiantes",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspirantesProgramas_AspirantesProgramasEstatus_AspiranteProgramaEstatusId",
                table: "AspirantesProgramas");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Personas_PersonaId",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_PersonaId",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_AspirantesProgramas_AspiranteProgramaEstatusId",
                table: "AspirantesProgramas");

            migrationBuilder.DropColumn(
                name: "AspiranteProgramaEstatusId",
                table: "AspirantesProgramas");
        }
    }
}
