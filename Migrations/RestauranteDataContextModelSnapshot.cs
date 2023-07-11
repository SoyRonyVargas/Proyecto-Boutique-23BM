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

            modelBuilder.Entity("ProyectoBoutique23BM.Clases.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("existencias_iniciales")
                        .HasColumnType("int");

                    b.Property<int>("existencias_restantes")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("precio")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            existencias_iniciales = 5,
                            existencias_restantes = 5,
                            nombre = "Hamburguesa con queso",
                            precio = 99.989999999999995
                        },
                        new
                        {
                            id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            existencias_iniciales = 5,
                            existencias_restantes = 5,
                            nombre = "Coca cola 600ml",
                            precio = 19.989999999999998
                        },
                        new
                        {
                            id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            existencias_iniciales = 5,
                            existencias_restantes = 5,
                            nombre = "Pepsi 600ml",
                            precio = 15.99
                        },
                        new
                        {
                            id = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            existencias_iniciales = 5,
                            existencias_restantes = 5,
                            nombre = "Papas fritas medianas",
                            precio = 49.990000000000002
                        },
                        new
                        {
                            id = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            existencias_iniciales = 5,
                            existencias_restantes = 5,
                            nombre = "Nuggets de pollo (6 piezas)",
                            precio = 89.989999999999995
                        });
                });

            modelBuilder.Entity("ProyectoBoutique23BM.Clases.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("apellidos")
                        .HasColumnType("longtext");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            apellidos = "Gomez",
                            correo = "prueba@gmail.com",
                            nombre = "Adamaris",
                            password = "1234"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
