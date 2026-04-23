using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDSW_1.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarTablaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Deudas_DeudaId",
                table: "Pagos");

            migrationBuilder.RenameColumn(
                name: "contraseñaHash",
                table: "Usuarios",
                newName: "contrasenaHash");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Deudas_DeudaId",
                table: "Pagos",
                column: "DeudaId",
                principalTable: "Deudas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Deudas_DeudaId",
                table: "Pagos");

            migrationBuilder.RenameColumn(
                name: "contrasenaHash",
                table: "Usuarios",
                newName: "contraseñaHash");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Deudas_DeudaId",
                table: "Pagos",
                column: "DeudaId",
                principalTable: "Deudas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
