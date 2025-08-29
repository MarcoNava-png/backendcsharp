using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_direcciones_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DireccionId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CodigoPostalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Direcciones_CodigosPostales_CodigoPostalId",
                        column: x => x.CodigoPostalId,
                        principalTable: "CodigosPostales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DireccionId",
                table: "Personas",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_CodigoPostalId",
                table: "Direcciones",
                column: "CodigoPostalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Direcciones_DireccionId",
                table: "Personas",
                column: "DireccionId",
                principalTable: "Direcciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Direcciones_DireccionId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropIndex(
                name: "IX_Personas_DireccionId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "DireccionId",
                table: "Personas");
        }
    }
}
