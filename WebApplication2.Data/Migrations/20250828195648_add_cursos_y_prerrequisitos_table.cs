using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_cursos_y_prerrequisitos_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Creditos = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prerrequisitos",
                columns: table => new
                {
                    CursoId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PrerrequisitoId = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prerrequisitos", x => new { x.CursoId, x.PrerrequisitoId });
                    table.ForeignKey(
                        name: "FK_Prerrequisitos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prerrequisitos_Cursos_PrerrequisitoId",
                        column: x => x.PrerrequisitoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_DepartamentoId",
                table: "Cursos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prerrequisitos_PrerrequisitoId",
                table: "Prerrequisitos",
                column: "PrerrequisitoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prerrequisitos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
