using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_inscripcion_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudianteId = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanEstudiosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscripciones_PlanEstudios_PlanEstudiosId",
                        column: x => x.PlanEstudiosId,
                        principalTable: "PlanEstudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EstudianteId",
                table: "Inscripciones",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_PlanEstudiosId",
                table: "Inscripciones",
                column: "PlanEstudiosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripciones");
        }
    }
}
