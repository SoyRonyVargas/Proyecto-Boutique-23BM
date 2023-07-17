using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto23BMBoutique2.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<int>(type: "int", nullable: false),
                    importe = table.Column<double>(type: "double", nullable: false),
                    iva = table.Column<double>(type: "double", nullable: false),
                    total = table.Column<double>(type: "double", nullable: false),
                    VendedorFK = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_VendedorFK",
                        column: x => x.VendedorFK,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VentasProductos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<double>(type: "double", nullable: false),
                    precio_pieza = table.Column<double>(type: "double", nullable: false),
                    importe = table.Column<double>(type: "double", nullable: false),
                    iva = table.Column<double>(type: "double", nullable: false),
                    total = table.Column<double>(type: "double", nullable: false),
                    VentaFK = table.Column<int>(type: "int", nullable: false),
                    ProductoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasProductos", x => x.id);
                    table.ForeignKey(
                        name: "FK_VentasProductos_Productos_ProductoFK",
                        column: x => x.ProductoFK,
                        principalTable: "Productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentasProductos_Ventas_VentaFK",
                        column: x => x.VentaFK,
                        principalTable: "Ventas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_VendedorFK",
                table: "Ventas",
                column: "VendedorFK");

            migrationBuilder.CreateIndex(
                name: "IX_VentasProductos_ProductoFK",
                table: "VentasProductos",
                column: "ProductoFK");

            migrationBuilder.CreateIndex(
                name: "IX_VentasProductos_VentaFK",
                table: "VentasProductos",
                column: "VentaFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentasProductos");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
