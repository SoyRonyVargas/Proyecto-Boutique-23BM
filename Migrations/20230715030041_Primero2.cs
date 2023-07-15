using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto23BMBoutique2.Migrations
{
    public partial class Primero2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categoria_CategoriaFK",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaFK",
                table: "Productos",
                column: "CategoriaFK",
                principalTable: "Categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaFK",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Categoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categoria_CategoriaFK",
                table: "Productos",
                column: "CategoriaFK",
                principalTable: "Categoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
