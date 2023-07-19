﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoBoutique23BM.Clases;

#nullable disable

namespace Proyecto23BMBoutique2.Migrations
{
    [DbContext(typeof(RestauranteDataContext))]
    partial class RestauranteDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Proyecto23BMBoutique2.Clases.Categoria", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            id = 1,
                            nombre = "Camisetas"
                        },
                        new
                        {
                            id = 2,
                            nombre = "Pantalones"
                        },
                        new
                        {
                            id = 3,
                            nombre = "Vestidos"
                        });
                });

            modelBuilder.Entity("Proyecto23BMBoutique2.Clases.Rol", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            id = 1,
                            nombre = "Root"
                        },
                        new
                        {
                            id = 2,
                            nombre = "Gerente"
                        },
                        new
                        {
                            id = 3,
                            nombre = "Vendedor"
                        });
                });

            modelBuilder.Entity("Proyecto23BMBoutique2.entradas.entities.Entrada", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Productoid")
                        .HasColumnType("int");

                    b.Property<int>("ProveedorFK")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioFK")
                        .HasColumnType("int");

                    b.Property<double>("importe")
                        .HasColumnType("double");

                    b.Property<double>("iva")
                        .HasColumnType("double");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("Productoid");

                    b.HasIndex("ProveedorFK");

                    b.HasIndex("UsuarioFK");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("Proyecto23BMBoutique2.entradas.entities.Entrada_Has_Producto", b =>
                {
                    b.Property<int>("EntradaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.HasKey("EntradaId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Entrada_Has_Producto");
                });

            modelBuilder.Entity("Proyecto23BMBoutique2.proveedores.entities.Proveedor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("contacto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("correo_electronico")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("empresa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Proyecto23BMBoutique2.ventas.entities.Venta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("VendedorFK")
                        .HasColumnType("int");

                    b.Property<double>("importe")
                        .HasColumnType("double");

                    b.Property<double>("iva")
                        .HasColumnType("double");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("VendedorFK");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Proyecto23BMBoutique2.ventas.entities.VentaProducto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProductoFK")
                        .HasColumnType("int");

                    b.Property<int>("VentaFK")
                        .HasColumnType("int");

                    b.Property<double>("cantidad")
                        .HasColumnType("double");

                    b.Property<double>("importe")
                        .HasColumnType("double");

                    b.Property<double>("iva")
                        .HasColumnType("double");

                    b.Property<double>("precio_pieza")
                        .HasColumnType("double");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("ProductoFK");

                    b.HasIndex("VentaFK");

                    b.ToTable("VentasProductos");
                });

            modelBuilder.Entity("ProyectoBoutique23BM.Clases.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("imagen")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CategoriaFK");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CategoriaFK = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            codigo = "P001",
                            descripcion = "Camiseta de manga corta",
                            imagen = "imagen1.jpg",
                            status = 1
                        },
                        new
                        {
                            id = 2,
                            CategoriaFK = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            codigo = "P002",
                            descripcion = "Pantalones vaqueros",
                            imagen = "imagen2.jpg",
                            status = 1
                        },
                        new
                        {
                            id = 3,
                            CategoriaFK = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            codigo = "P003",
                            descripcion = "Vestido de fiesta",
                            imagen = "imagen3.jpg",
                            status = 1
                        },
                        new
                        {
                            id = 4,
                            CategoriaFK = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            codigo = "P004",
                            descripcion = "Chaqueta de cuero",
                            imagen = "imagen4.jpg",
                            status = 1
                        },
                        new
                        {
                            id = 5,
                            CategoriaFK = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            codigo = "P005",
                            descripcion = "Zapatos de tacón",
                            imagen = "imagen5.jpg",
                            status = 1
                        });
                });

            modelBuilder.Entity("ProyectoBoutique23BM.Clases.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RolFK")
                        .HasColumnType("int");

                    b.Property<string>("apellidos")
                        .HasColumnType("longtext");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("nombreUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("RolFK");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            id = 1,
                            RolFK = 1,
                            apellidos = "Gomez",
                            correo = "prueba@gmail.com",
                            nombre = "Adamaris",
                            nombreUsuario = "cazadordeabuelas",
                            password = "1234"
                        });
                });

            modelBuilder.Entity("Proyecto23BMBoutique2.entradas.entities.Entrada", b =>
                {
                    b.HasOne("ProyectoBoutique23BM.Clases.Producto", null)
                        .WithMany("Entradas")
                        .HasForeignKey("Productoid");

                    b.HasOne("Proyecto23BMBoutique2.proveedores.entities.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoBoutique23BM.Clases.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Proyecto23BMBoutique2.entradas.entities.Entrada_Has_Producto", b =>
                {
                    b.HasOne("Proyecto23BMBoutique2.entradas.entities.Entrada", "Entrada")
                        .WithMany()
                        .HasForeignKey("EntradaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoBoutique23BM.Clases.Producto", "Producto")
                        .WithMany("EntradaProductos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entrada");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Proyecto23BMBoutique2.ventas.entities.Venta", b =>
                {
                    b.HasOne("ProyectoBoutique23BM.Clases.Usuario", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("Proyecto23BMBoutique2.ventas.entities.VentaProducto", b =>
                {
                    b.HasOne("ProyectoBoutique23BM.Clases.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto23BMBoutique2.ventas.entities.Venta", "Venta")
                        .WithMany("Productos")
                        .HasForeignKey("VentaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("ProyectoBoutique23BM.Clases.Producto", b =>
                {
                    b.HasOne("Proyecto23BMBoutique2.Clases.Categoria", "CatActual")
                        .WithMany()
                        .HasForeignKey("CategoriaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatActual");
                });

            modelBuilder.Entity("ProyectoBoutique23BM.Clases.Usuario", b =>
                {
                    b.HasOne("Proyecto23BMBoutique2.Clases.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Proyecto23BMBoutique2.ventas.entities.Venta", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("ProyectoBoutique23BM.Clases.Producto", b =>
                {
                    b.Navigation("EntradaProductos");

                    b.Navigation("Entradas");
                });
#pragma warning restore 612, 618
        }
    }
}
