using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto23BMBoutique2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Entrada_Has_Producto",
                newName: "cantidad");

            migrationBuilder.AddColumn<double>(
                name: "precio",
                table: "Productos",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "importe",
                table: "Entrada_Has_Producto",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "iva",
                table: "Entrada_Has_Producto",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "total",
                table: "Entrada_Has_Producto",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "precio",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "importe",
                table: "Entrada_Has_Producto");

            migrationBuilder.DropColumn(
                name: "iva",
                table: "Entrada_Has_Producto");

            migrationBuilder.DropColumn(
                name: "total",
                table: "Entrada_Has_Producto");

            migrationBuilder.RenameColumn(
                name: "cantidad",
                table: "Entrada_Has_Producto",
                newName: "Cantidad");
        }
    }
}
