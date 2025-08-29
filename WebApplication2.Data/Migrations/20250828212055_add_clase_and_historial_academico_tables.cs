using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_clase_and_historial_academico_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanEstudiosId = table.Column<int>(type: "int", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false),
                    Periodicidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupos_PlanEstudios_PlanEstudiosId",
                        column: x => x.PlanEstudiosId,
                        principalTable: "PlanEstudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanEstudiosId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    HorarioId = table.Column<int>(type: "int", nullable: false),
                    CupoMaximo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seccion_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seccion_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seccion_PlanEstudios_PlanEstudiosId",
                        column: x => x.PlanEstudiosId,
                        principalTable: "PlanEstudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seccion_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeccionId = table.Column<int>(type: "int", nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    HorarioId = table.Column<int>(type: "int", nullable: false),
                    HorarioDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clases_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clases_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clases_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clases_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clases_Seccion_SeccionId",
                        column: x => x.SeccionId,
                        principalTable: "Seccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistorialAcademico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudianteId = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    CursoId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ClaseId = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CalificacionFinal = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialAcademico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialAcademico_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialAcademico_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistorialAcademico_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clases_CursoId",
                table: "Clases",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_GrupoId",
                table: "Clases",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_HorarioId",
                table: "Clases",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_ProfesorId",
                table: "Clases",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_SeccionId",
                table: "Clases",
                column: "SeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_PlanEstudiosId",
                table: "Grupos",
                column: "PlanEstudiosId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialAcademico_ClaseId",
                table: "HistorialAcademico",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialAcademico_CursoId",
                table: "HistorialAcademico",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialAcademico_EstudianteId",
                table: "HistorialAcademico",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Seccion_CursoId",
                table: "Seccion",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Seccion_HorarioId",
                table: "Seccion",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Seccion_PlanEstudiosId",
                table: "Seccion",
                column: "PlanEstudiosId");

            migrationBuilder.CreateIndex(
                name: "IX_Seccion_ProfesorId",
                table: "Seccion",
                column: "ProfesorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialAcademico");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Seccion");
        }
    }
}
