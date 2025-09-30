using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication2.Core.Common;

#nullable disable

namespace WebApplication2.Data.Migrations
{
    /// <inheritdoc />
    public partial class alter_table_personas_add_column_status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estatus",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: StatusEnum.Activo);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Personas");
        }
    }
}
