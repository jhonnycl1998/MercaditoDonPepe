using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDSW_1.Migrations
{
    /// <inheritdoc />
    public partial class DiaCorte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCorte",
                table: "Servicios");

            migrationBuilder.AddColumn<int>(
                name: "DiaCorte",
                table: "Servicios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaCorte",
                table: "Servicios");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCorte",
                table: "Servicios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
