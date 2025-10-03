using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class genero_initial_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "PersonasGenero",
            columns: ["Id", "Genero"],
            values: new object[,]
            {
                { 1, "Masculino" },
                { 2, "Femenino" }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "PersonasGenero",
            keyColumn: "Id",
            keyValues: [1, 2]);
        }
    }
}
