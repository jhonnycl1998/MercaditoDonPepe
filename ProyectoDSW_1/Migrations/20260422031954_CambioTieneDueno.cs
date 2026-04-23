using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDSW_1.Migrations
{
    /// <inheritdoc />
    public partial class CambioTieneDueno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TieneDueño",
                table: "Tiendas",
                newName: "TieneDueno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TieneDueno",
                table: "Tiendas",
                newName: "TieneDueño");
        }
    }
}
