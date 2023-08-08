using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto23BMBoutique2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contacto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    empresa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    correo_electronico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<int>(type: "int", nullable: false),
                    imagen = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precio = table.Column<double>(type: "double", nullable: false),
                    existencias = table.Column<int>(type: "int", nullable: false),
                    CategoriaFK = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaFK",
                        column: x => x.CategoriaFK,
                        principalTable: "Categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellidos = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    correo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombreUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagen = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RolFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolFK",
                        column: x => x.RolFK,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<int>(type: "int", nullable: false),
                    importe = table.Column<double>(type: "double", nullable: false),
                    iva = table.Column<double>(type: "double", nullable: false),
                    total = table.Column<double>(type: "double", nullable: false),
                    ProveedorFK = table.Column<int>(type: "int", nullable: false),
                    UsuarioFK = table.Column<int>(type: "int", nullable: false),
                    Productoid = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entradas_Productos_Productoid",
                        column: x => x.Productoid,
                        principalTable: "Productos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Entradas_Proveedores_ProveedorFK",
                        column: x => x.ProveedorFK,
                        principalTable: "Proveedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entradas_Usuarios_UsuarioFK",
                        column: x => x.UsuarioFK,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "Entrada_Has_Producto",
                columns: table => new
                {
                    EntradaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    importe = table.Column<double>(type: "double", nullable: false),
                    iva = table.Column<double>(type: "double", nullable: false),
                    total = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada_Has_Producto", x => new { x.EntradaId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_Entrada_Has_Producto_Entradas_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "Entradas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrada_Has_Producto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
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

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "id", "nombre" },
                values: new object[,]
                {
                    { 1, "Camisetas" },
                    { 2, "Pantalones" },
                    { 3, "Vestidos" }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "id", "CreatedDate", "contacto", "correo_electronico", "direccion", "empresa", "nombre", "status", "telefono" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contacto", "oscar@empresa1.com", "Dirección1", "Empresa1", "Oscar", 1, "123456789" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contacto", "lucia@empresa2.com", "Dirección2", "Empresa2", "Lucía", 1, "987654321" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contacto", "carlos@empresa3.com", "Dirección3", "Empresa3", "Carlos", 1, "456789123" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contacto", "laura@empresa4.com", "Dirección4", "Empresa4", "Laura", 1, "789123456" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contacto", "miguel@empresa5.com", "Dirección5", "Empresa5", "Miguel", 1, "321654987" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "nombre" },
                values: new object[,]
                {
                    { 1, "Root" },
                    { 2, "Gerente" },
                    { 3, "Vendedor" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "id", "CategoriaFK", "CreatedDate", "codigo", "descripcion", "existencias", "imagen", "precio", "status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P001", "Camiseta de manga corta JOJI", 0, "https://img.elo7.com.br/product/zoom/31043A7/camiseta-algodao-pink-guy-bad-vibe-indie-retro-joji-filthy-guy.jpg", 199.99000000000001, 1 },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P002", "Pantalones De Lápiz", 0, "https://m.media-amazon.com/images/I/71ELCXal0nS._AC_UF894,1000_QL80_.jpg", 299.99000000000001, 1 },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P003", "Pantalones joggers", 0, "https://down-mx.img.susercontent.com/file/68f810f3195cf9e17de5d5a8c9bc7db4", 299.99000000000001, 1 },
                    { 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P003", "Lentes De Sol Blancas Estilo Hip-Hop", 0, "https://m.media-amazon.com/images/I/31hV8MpgCQL._AC_SY580_.jpg", 659.99000000000001, 1 },
                    { 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P003", "Vestido De Terciopelo Para Mujer", 0, "https://m.media-amazon.com/images/I/71FA4gYrZJL._AC_SX342_.jpg", 1599.99, 1 },
                    { 6, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P003", " Vestido de Novia Vestido de Novia Top de Encaje Vestido de Dama de Honor de la Boda Vestido de Fiesta de graduación Largo Elegante Regalo Nupcial", 0, "https://m.media-amazon.com/images/I/716ZepRUgSL._AC_UF894,1000_QL80_.jpg", 6999.9899999999998, 1 },
                    { 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P005", "Tenis yeezy", 0, "https://m.media-amazon.com/images/I/711gDC-38fL._AC_UY1000_.jpg", 1799.99, 1 },
                    { 8, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P005", "Boxers calvin klein", 0, "https://calvinargentina.vteximg.com.br/arquivos/ids/181157-470-620/NB2614-001_1.jpg?v=638114762715830000", 659.88999999999999, 1 },
                    { 9, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P005", "Zapatos De Payaso Profesional Multicolor Tamaño Mediano", 0, "https://http2.mlstatic.com/D_NQ_NP_922495-MLM31368805414_072019-W.jpg", 1595.99, 1 },
                    { 10, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P005", "Nariz de payaso", 0, "https://media.istockphoto.com/id/851634552/es/foto/nariz-de-payaso-sobre-fondo-blanco.jpg?s=612x612&w=0&k=20&c=YOdX2gaDFUFz6jull7GPk6MblYu2h2Ad-GJHquSPbZQ=", 128.0, 1 },
                    { 11, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P005", "Traje de payaso", 0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcToGkBvYCLMI_5CjDQxby8mZ80ma_s4Y7xzNQ&usqp=CAU", 999.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "id", "Imagen", "RolFK", "apellidos", "correo", "nombre", "nombreUsuario", "password" },
                values: new object[,]
                {
                    { 1, "123123123123123123123", 1, "Aguilar", "martin@gmail.com", "Martin", "martin", "1234" },
                    { 2, "123123123123123123123", 2, "Robles", "edison@gmail.com", "Edison", "edison", "1234" },
                    { 3, "123123123123123123123", 3, "Mendez", "angel@gmail.com", "Angel", "angel", "1234" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_Has_Producto_ProductoId",
                table: "Entrada_Has_Producto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_Productoid",
                table: "Entradas",
                column: "Productoid");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_ProveedorFK",
                table: "Entradas",
                column: "ProveedorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_UsuarioFK",
                table: "Entradas",
                column: "UsuarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaFK",
                table: "Productos",
                column: "CategoriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolFK",
                table: "Usuarios",
                column: "RolFK");

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
                name: "Entrada_Has_Producto");

            migrationBuilder.DropTable(
                name: "VentasProductos");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
