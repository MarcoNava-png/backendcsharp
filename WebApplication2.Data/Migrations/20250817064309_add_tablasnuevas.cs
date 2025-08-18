using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_tablasnuevas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_AspNetUsers_UserId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_PersonasGenero_PersonaGeneroId",
                table: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Personas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoPaterno",
                table: "Personas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "Personas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CorreoElectronico",
                table: "Personas",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DireccionId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Personas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PersonaEstadoCivilId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Personas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "lookup_persona_estado_civil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoCivil = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lookup_persona_estado_civil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoIso = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "codigo_postal",
                columns: table => new
                {
                    id_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_municipio = table.Column<int>(type: "int", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    colonia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_codigo_postal", x => x.id_codigo);
                    table.ForeignKey(
                        name: "FK_codigo_postal_Municipios_id_municipio",
                        column: x => x.id_municipio,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "direccion",
                columns: table => new
                {
                    id_direccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    id_codigo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion", x => x.id_direccion);
                    table.ForeignKey(
                        name: "FK_direccion_codigo_postal_id_codigo",
                        column: x => x.id_codigo,
                        principalTable: "codigo_postal",
                        principalColumn: "id_codigo",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "lookup_persona_estado_civil",
                columns: new[] { "Id", "EstadoCivil" },
                values: new object[,]
                {
                    { 1, "Soltero(a)" },
                    { 2, "Casado(a)" },
                    { 3, "Divorciado(a)" },
                    { 4, "Viudo(a)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DireccionId",
                table: "Personas",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PersonaEstadoCivilId",
                table: "Personas",
                column: "PersonaEstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_codigo_postal_id_municipio",
                table: "codigo_postal",
                column: "id_municipio");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_id_codigo",
                table: "direccion",
                column: "id_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_PaisId",
                table: "Estados",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_EstadoId",
                table: "Municipios",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_AspNetUsers_UserId",
                table: "Personas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_PersonasGenero_PersonaGeneroId",
                table: "Personas",
                column: "PersonaGeneroId",
                principalTable: "PersonasGenero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_direccion_DireccionId",
                table: "Personas",
                column: "DireccionId",
                principalTable: "direccion",
                principalColumn: "id_direccion",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_lookup_persona_estado_civil_PersonaEstadoCivilId",
                table: "Personas",
                column: "PersonaEstadoCivilId",
                principalTable: "lookup_persona_estado_civil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_AspNetUsers_UserId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_PersonasGenero_PersonaGeneroId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_direccion_DireccionId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_lookup_persona_estado_civil_PersonaEstadoCivilId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "lookup_persona_estado_civil");

            migrationBuilder.DropTable(
                name: "codigo_postal");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Personas_DireccionId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PersonaEstadoCivilId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "CorreoElectronico",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "DireccionId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PersonaEstadoCivilId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoPaterno",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_AspNetUsers_UserId",
                table: "Personas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_PersonasGenero_PersonaGeneroId",
                table: "Personas",
                column: "PersonaGeneroId",
                principalTable: "PersonasGenero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
