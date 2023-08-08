using Microsoft.EntityFrameworkCore;
using Proyecto23BMBoutique2.Clases;
using Proyecto23BMBoutique2.entradas.entities;
using Proyecto23BMBoutique2.proveedores.entities;
using Proyecto23BMBoutique2.ventas.entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace ProyectoBoutique23BM.Clases
{
    public class RestauranteDataContext : DbContext
    {
        static readonly string connectionString = "Server=localhost;port=3306;User ID=root ; Password=; Database=Boutique23BM";

        public DbSet<Producto>Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaProducto> VentasProductos { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al conectar la base de datos");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Entrada_Has_Producto>()
                .HasKey(ep => new { ep.EntradaId, ep.ProductoId });

            modelBuilder.Entity<Entrada_Has_Producto>()
                .HasOne(ep => ep.Entrada)
                .WithMany(e => e.EntradaProductos)
                .HasForeignKey(ep => ep.EntradaId);

            modelBuilder.Entity<Entrada_Has_Producto>()
                .HasOne(ep => ep.Producto)
                .WithMany(p => p.EntradaProductos)
                .HasForeignKey(ep => ep.ProductoId);

            // Proveedor 1
            modelBuilder.Entity<Proveedor>().HasData(new Proveedor
            {
                id = 1,
                nombre = "Oscar",
                contacto = "Contacto",
                empresa = "Empresa1",
                direccion = "Dirección1",
                telefono = "123456789",
                correo_electronico = "oscar@empresa1.com",
                status = 1
            });

            // Proveedor 2
            modelBuilder.Entity<Proveedor>().HasData(new Proveedor
            {
                id = 2,
                nombre = "Lucía",
                contacto = "Contacto",
                empresa = "Empresa2",
                direccion = "Dirección2",
                telefono = "987654321",
                correo_electronico = "lucia@empresa2.com",
                status = 1
            });

            // Proveedor 3
            modelBuilder.Entity<Proveedor>().HasData(new Proveedor
            {
                id = 3,
                nombre = "Carlos",
                contacto = "Contacto",
                empresa = "Empresa3",
                direccion = "Dirección3",
                telefono = "456789123",
                correo_electronico = "carlos@empresa3.com",
                status = 1
            });

            // Proveedor 4
            modelBuilder.Entity<Proveedor>().HasData(new Proveedor
            {
                id = 4,
                nombre = "Laura",
                contacto = "Contacto",
                empresa = "Empresa4",
                direccion = "Dirección4",
                telefono = "789123456",
                correo_electronico = "laura@empresa4.com",
                status = 1
            });

            // Proveedor 5
            modelBuilder.Entity<Proveedor>().HasData(new Proveedor
            {
                id = 5,
                nombre = "Miguel",
                contacto = "Contacto",
                empresa = "Empresa5",
                direccion = "Dirección5",
                telefono = "321654987",
                correo_electronico = "miguel@empresa5.com",
                status = 1
            });

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
                    apellidos = "Aguilar",
                    nombre = "Martin",
                    correo = "martin@gmail.com",
                    password = "1234",
                    nombreUsuario = "martin",
                    RolFK = 1,
                    Imagen = "123123123123123123123",
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {
                   id = 2,
                   apellidos = "Robles",
                   nombre = "Edison",
                   correo = "edison@gmail.com",
                   password = "1234",
                   nombreUsuario = "edison",
                   RolFK = 2,
                   Imagen = "123123123123123123123",
               }
           );

            modelBuilder.Entity<Usuario>().HasData(
              new Usuario
              {
                  id = 3,
                  apellidos = "Mendez",
                  nombre = "Angel",
                  correo = "angel@gmail.com",
                  password = "1234",
                  nombreUsuario = "angel",
                  RolFK = 3,
                  Imagen = "123123123123123123123",
              }
          );

            modelBuilder.Entity<Producto>().HasData(
                 new Producto
                 {
                     id = 1,
                     status = 1,
                     imagen = "https://img.elo7.com.br/product/zoom/31043A7/camiseta-algodao-pink-guy-bad-vibe-indie-retro-joji-filthy-guy.jpg",
                     codigo = "P001",
                     descripcion = "Camiseta de manga corta JOJI",
                     CategoriaFK = 1,
                     precio = 199.99,
                     existencias = 0
                 },
                 new Producto
                 {
                     id = 2,
                     status = 1,
                     imagen = "https://m.media-amazon.com/images/I/71ELCXal0nS._AC_UF894,1000_QL80_.jpg",
                     codigo = "P002",
                     descripcion = "Pantalones De Lápiz",
                     CategoriaFK = 2,
                     precio = 299.99,
                     existencias = 0
                 },
                  new Producto
                  {
                      id = 3,
                      status = 1,
                      imagen = "https://down-mx.img.susercontent.com/file/68f810f3195cf9e17de5d5a8c9bc7db4",
                      codigo = "P003",
                      descripcion = "Pantalones joggers",
                      CategoriaFK = 2,
                      precio = 299.99,
                      existencias = 0
                  },
                  new Producto
                  {
                      id = 4,
                      status = 1,
                      imagen = "https://m.media-amazon.com/images/I/31hV8MpgCQL._AC_SY580_.jpg",
                      codigo = "P003",
                      descripcion = "Lentes De Sol Blancas Estilo Hip-Hop",
                      CategoriaFK = 2,
                      precio = 659.99,
                      existencias = 0
                  },
                  new Producto
                  {
                      id = 5,
                      status = 1,
                      imagen = "https://m.media-amazon.com/images/I/71FA4gYrZJL._AC_SX342_.jpg",
                      codigo = "P003",
                      descripcion = "Vestido De Terciopelo Para Mujer",
                      CategoriaFK = 2,
                      precio = 1599.99,
                      existencias = 0
                  },
                 new Producto
                 {
                     id = 6,
                     status = 1,
                     imagen = "https://m.media-amazon.com/images/I/716ZepRUgSL._AC_UF894,1000_QL80_.jpg",
                     codigo = "P003",
                     descripcion = " Vestido de Novia Vestido de Novia Top de Encaje Vestido de Dama de Honor de la Boda Vestido de Fiesta de graduación Largo Elegante Regalo Nupcial",
                     CategoriaFK = 3,
                     precio = 6999.99,
                     existencias = 0
                 },
                 new Producto
                 {
                     id = 7,
                     status = 1,
                     imagen = "https://m.media-amazon.com/images/I/711gDC-38fL._AC_UY1000_.jpg",
                     codigo = "P005",
                     descripcion = "Tenis yeezy",
                     CategoriaFK = 1,
                     precio = 1799.99,
                     existencias = 0
                 },
                 new Producto
                 {
                     id = 8,
                     status = 1,
                     imagen = "https://calvinargentina.vteximg.com.br/arquivos/ids/181157-470-620/NB2614-001_1.jpg?v=638114762715830000",
                     codigo = "P005",
                     descripcion = "Boxers calvin klein",
                     CategoriaFK = 1,
                     precio = 659.89,
                     existencias = 0
                 },
                 new Producto
                 {
                     id = 9,
                     status = 1,
                     imagen = "https://http2.mlstatic.com/D_NQ_NP_922495-MLM31368805414_072019-W.jpg",
                     codigo = "P005",
                     descripcion = "Zapatos De Payaso Profesional Multicolor Tamaño Mediano",
                     CategoriaFK = 1,
                     precio = 1595.99,
                     existencias = 0
                 },
                 new Producto
                 {
                     id = 10,
                     status = 1,
                     imagen = "https://media.istockphoto.com/id/851634552/es/foto/nariz-de-payaso-sobre-fondo-blanco.jpg?s=612x612&w=0&k=20&c=YOdX2gaDFUFz6jull7GPk6MblYu2h2Ad-GJHquSPbZQ=",
                     codigo = "P005",
                     descripcion = "Nariz de payaso",
                     CategoriaFK = 1,
                     precio = 128.00,
                     existencias = 0
                 },
                 new Producto
                 {
                     id = 11,
                     status = 1,
                     imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcToGkBvYCLMI_5CjDQxby8mZ80ma_s4Y7xzNQ&usqp=CAU",
                     codigo = "P005",
                     descripcion = "Traje de payaso",
                     CategoriaFK = 1,
                     precio = 999.00,
                     existencias = 0
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
