using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto23BMBoutique2.Migrations
{
    public partial class EntradasProveedores2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaProducto");

            migrationBuilder.AddColumn<int>(
                name: "Productoid",
                table: "Entradas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_Productoid",
                table: "Entradas",
                column: "Productoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Productos_Productoid",
                table: "Entradas",
                column: "Productoid",
                principalTable: "Productos",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Productos_Productoid",
                table: "Entradas");

            migrationBuilder.DropIndex(
                name: "IX_Entradas_Productoid",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "Productoid",
                table: "Entradas");

            migrationBuilder.CreateTable(
                name: "EntradaProducto",
                columns: table => new
                {
                    Entradasid = table.Column<int>(type: "int", nullable: false),
                    Productosid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaProducto", x => new { x.Entradasid, x.Productosid });
                    table.ForeignKey(
                        name: "FK_EntradaProducto_Entradas_Entradasid",
                        column: x => x.Entradasid,
                        principalTable: "Entradas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradaProducto_Productos_Productosid",
                        column: x => x.Productosid,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaProducto_Productosid",
                table: "EntradaProducto",
                column: "Productosid");
        }
    }
}
