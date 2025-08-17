using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_Estudiante_tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    id_departamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.id_departamento);
                });

            migrationBuilder.CreateTable(
                name: "estudiante_estatus_academico",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiante_estatus_academico", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programa_estudios",
                columns: table => new
                {
                    id_programa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_departamento = table.Column<int>(type: "int", nullable: true),
                    nivel_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programa_estudios", x => x.id_programa);
                    table.ForeignKey(
                        name: "FK_programa_estudios_departamento_id_departamento",
                        column: x => x.id_departamento,
                        principalTable: "departamento",
                        principalColumn: "id_departamento",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "estudiante",
                columns: table => new
                {
                    matricula = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    id_persona = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fecha_ingreso = table.Column<DateTime>(type: "date", nullable: true),
                    nivel_educativo_id = table.Column<int>(type: "int", nullable: true),
                    estatus_id = table.Column<int>(type: "int", nullable: true),
                    estatus_academico_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiante", x => x.matricula);
                    table.ForeignKey(
                        name: "FK_estudiante_Personas_id_persona",
                        column: x => x.id_persona,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_estudiante_estudiante_estatus_academico_estatus_academico_id",
                        column: x => x.estatus_academico_id,
                        principalTable: "estudiante_estatus_academico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "plan_estudios",
                columns: table => new
                {
                    id_plan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    rvoe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    permite_adelantar = table.Column<bool>(type: "bit", nullable: false),
                    version = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    id_programa = table.Column<int>(type: "int", nullable: true),
                    duracion_meses = table.Column<int>(type: "int", nullable: true, defaultValue: 48),
                    periodicidad_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plan_estudios", x => x.id_plan);
                    table.ForeignKey(
                        name: "FK_plan_estudios_programa_estudios_id_programa",
                        column: x => x.id_programa,
                        principalTable: "programa_estudios",
                        principalColumn: "id_programa",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "estudiante_estatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matricula = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    fecha_desde = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estatus_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiante_estatus", x => x.id);
                    table.ForeignKey(
                        name: "FK_estudiante_estatus_estudiante_estatus_academico_estatus_id",
                        column: x => x.estatus_id,
                        principalTable: "estudiante_estatus_academico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_estudiante_estatus_estudiante_matricula",
                        column: x => x.matricula,
                        principalTable: "estudiante",
                        principalColumn: "matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_estudiante_estatus_academico_id",
                table: "estudiante",
                column: "estatus_academico_id");

            migrationBuilder.CreateIndex(
                name: "IX_estudiante_id_persona",
                table: "estudiante",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_estudiante_estatus_estatus_id",
                table: "estudiante_estatus",
                column: "estatus_id");

            migrationBuilder.CreateIndex(
                name: "IX_estudiante_estatus_matricula",
                table: "estudiante_estatus",
                column: "matricula");

            migrationBuilder.CreateIndex(
                name: "IX_plan_estudios_id_programa",
                table: "plan_estudios",
                column: "id_programa");

            migrationBuilder.CreateIndex(
                name: "IX_programa_estudios_id_departamento",
                table: "programa_estudios",
                column: "id_departamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estudiante_estatus");

            migrationBuilder.DropTable(
                name: "plan_estudios");

            migrationBuilder.DropTable(
                name: "estudiante");

            migrationBuilder.DropTable(
                name: "programa_estudios");

            migrationBuilder.DropTable(
                name: "estudiante_estatus_academico");

            migrationBuilder.DropTable(
                name: "departamento");
        }
    }
}
