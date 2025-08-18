using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Personas_PersonaId",
                table: "Profesores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores");

            migrationBuilder.DropIndex(
                name: "IX_Profesores_PersonaId",
                table: "Profesores");

            migrationBuilder.RenameTable(
                name: "Profesores",
                newName: "profesor");

            migrationBuilder.RenameColumn(
                name: "PersonaId",
                table: "profesor",
                newName: "id_persona");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "profesor",
                newName: "id_profesor");

            migrationBuilder.AlterColumn<string>(
                name: "Especialidad",
                table: "profesor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "profesor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "profesor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_profesor",
                table: "profesor",
                column: "id_profesor");

            migrationBuilder.CreateIndex(
                name: "IX_profesor_id_persona",
                table: "profesor",
                column: "id_persona",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_profesor_Personas_id_persona",
                table: "profesor",
                column: "id_persona",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profesor_Personas_id_persona",
                table: "profesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_profesor",
                table: "profesor");

            migrationBuilder.DropIndex(
                name: "IX_profesor_id_persona",
                table: "profesor");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "profesor");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "profesor");

            migrationBuilder.RenameTable(
                name: "profesor",
                newName: "Profesores");

            migrationBuilder.RenameColumn(
                name: "id_persona",
                table: "Profesores",
                newName: "PersonaId");

            migrationBuilder.RenameColumn(
                name: "id_profesor",
                table: "Profesores",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Especialidad",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_PersonaId",
                table: "Profesores",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Personas_PersonaId",
                table: "Profesores",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
