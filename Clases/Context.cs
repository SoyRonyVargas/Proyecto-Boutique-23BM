using Microsoft.EntityFrameworkCore;
using Proyecto23BMBoutique2.Clases;
using Proyecto23BMBoutique2.ventas.entities;
using System;
using System.Diagnostics;
using System.Windows;

namespace ProyectoBoutique23BM.Clases
{
    public class RestauranteDataContext : DbContext
    {
        static readonly string connectionString = "Server=localhost;port=3306;User ID=root2; Password=; Database=Boutique23BM";

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaProducto> VentasProductos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {

                // SI OCUPAS SQLSERVER USA ESTA

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

                // SI OCUPAS MYSQL USA ESTA

            }
            catch(Exception e)
            {
                Console.WriteLine("Error al conectar la base de datos");
                Debugger.Break();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    id = 1,
                    nombre = "Root",
                }
            );

            modelBuilder.Entity<Rol>().HasData(
               new Rol
               {
                   id = 2,
                   nombre = "Gerente",
               }
            );

            modelBuilder.Entity<Rol>().HasData(
              new Rol
              {
                  id = 3,
                  nombre = "Vendedor",
              }
            );

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    id = 1,
                    nombre = "Camisetas"
                },
                new Categoria
                {
                    id = 2,
                    nombre = "Pantalones"
                },
                new Categoria
                {
                    id = 3,
                    nombre = "Vestidos"
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    id = 1,
                    apellidos = "Gomez",
                    nombre = "Adamaris",
                    correo = "prueba@gmail.com",
                    password = "1234",
                    nombreUsuario = "cazadordeabuelas",
                    RolFK = 1,
                }
            );

            modelBuilder.Entity<Producto>().HasData(
                 new Producto
                 {
                     id = 1,
                     status = 1,
                     imagen = "imagen1.jpg",
                     codigo = "P001",
                     descripcion = "Camiseta de manga corta",
                     CategoriaFK = 1
                 },
                 new Producto
                 {
                     id = 2,
                     status = 1,
                     imagen = "imagen2.jpg",
                     codigo = "P002",
                     descripcion = "Pantalones vaqueros",
                     CategoriaFK = 2
                 },
                 new Producto
                 {
                     id = 3,
                     status = 1,
                     imagen = "imagen3.jpg",
                     codigo = "P003",
                     descripcion = "Vestido de fiesta",
                     CategoriaFK = 3
                 },
                 new Producto
                 {
                     id = 4,
                     status = 1,
                     imagen = "imagen4.jpg",
                     codigo = "P004",
                     descripcion = "Chaqueta de cuero",
                     CategoriaFK = 1
                 },
                 new Producto
                 {
                     id = 5,
                     status = 1,
                     imagen = "imagen5.jpg",
                     codigo = "P005",
                     descripcion = "Zapatos de tacón",
                     CategoriaFK = 1
                 }
             );


        }

        public override int SaveChanges()
        {
            //var entries = ChangeTracker
            //    .Entries()
            //    .Where(e => e.Entity is BaseEntity && (
            //            e.State == EntityState.Added
            //            || e.State == EntityState.Modified));

            //foreach (var entityEntry in entries)
            //{
            //    if (entityEntry.State == EntityState.Added)
            //    {
            //        ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
            //    }
            //}

            return base.SaveChanges();
        }

    }
}
