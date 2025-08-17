using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_tablas_aspirante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aspirante_estatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspirante_estatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programa",
                columns: table => new
                {
                    id_programa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programa", x => x.id_programa);
                });

            migrationBuilder.CreateTable(
                name: "aspirante",
                columns: table => new
                {
                    id_aspirante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_persona = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fecha_registro = table.Column<DateTime>(type: "date", nullable: true),
                    estatus_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspirante", x => x.id_aspirante);
                    table.ForeignKey(
                        name: "FK_aspirante_Personas_id_persona",
                        column: x => x.id_persona,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_aspirante_aspirante_estatus_estatus_id",
                        column: x => x.estatus_id,
                        principalTable: "aspirante_estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "aspirante_programa",
                columns: table => new
                {
                    id_aspirante = table.Column<int>(type: "int", nullable: false),
                    id_programa = table.Column<int>(type: "int", nullable: false),
                    fecha_postulacion = table.Column<DateTime>(type: "date", nullable: false),
                    estatus_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspirante_programa", x => new { x.id_aspirante, x.id_programa });
                    table.ForeignKey(
                        name: "FK_aspirante_programa_aspirante_estatus_estatus_id",
                        column: x => x.estatus_id,
                        principalTable: "aspirante_estatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_aspirante_programa_aspirante_id_aspirante",
                        column: x => x.id_aspirante,
                        principalTable: "aspirante",
                        principalColumn: "id_aspirante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aspirante_programa_programa_id_programa",
                        column: x => x.id_programa,
                        principalTable: "programa",
                        principalColumn: "id_programa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "aspirante_estatus",
                columns: new[] { "id", "estatus" },
                values: new object[,]
                {
                    { 1, "Pre-registrado" },
                    { 2, "En revisión" },
                    { 3, "Aceptado" },
                    { 4, "Rechazado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_aspirante_estatus_id",
                table: "aspirante",
                column: "estatus_id");

            migrationBuilder.CreateIndex(
                name: "IX_aspirante_id_persona",
                table: "aspirante",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_aspirante_programa_estatus_id",
                table: "aspirante_programa",
                column: "estatus_id");

            migrationBuilder.CreateIndex(
                name: "IX_aspirante_programa_id_programa",
                table: "aspirante_programa",
                column: "id_programa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aspirante_programa");

            migrationBuilder.DropTable(
                name: "aspirante");

            migrationBuilder.DropTable(
                name: "programa");

            migrationBuilder.DropTable(
                name: "aspirante_estatus");
        }
    }
}
