using ProyectoBoutique23BM.Clases;
using System.Collections.Generic;
using System.Linq;
using System;
using Proyecto23BMBoutique2.Clases;
using Microsoft.EntityFrameworkCore;

namespace Proyecto23BMBoutique2.producto.services
{
    internal class ProductoService
    {
        private RestauranteDataContext db = new RestauranteDataContext();

        // Create
        public bool AgregarProducto(Producto producto)
        {
            try
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Read
        public List<Producto> ObtenerTodosLosProductos()
        {
            try
            {
                return db.Productos.Include(x => x.CatActual).ToList();
            }
            catch(Exception ex) 
            {

                Errors.handle(ex);
                return new List<Producto> { };
            }
            
        }

        public List<Producto> ObtenerProductosPorNombre(string nombre)
        {
            try
            {
                List<Producto> productos = db.Productos.Where(p => p.descripcion.Contains(nombre)).ToList();

                return productos;
            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return null;
            }
        }

        public Producto? ObtenerProductoPorId(int id)
        {
            try
            {
                Producto? producto = db.Productos.FirstOrDefault(p => p.id == id);
                
                return producto;

            }
            catch(Exception ex) 
            {
                Errors.handle(ex);
                return null;
            }
        }

        // Update
        public bool ActualizarProducto(Producto productoDTO)
        {
            try
            {
                Producto? productoExistente = db.Productos
                    .FirstOrDefault(p => p.id == productoDTO.id);

                if (productoExistente != null)
                {
                    productoExistente.imagen = productoDTO.imagen;
                    productoExistente.descripcion = productoDTO.descripcion;
                    productoExistente.status = productoDTO.status;
                    productoExistente.CategoriaFK = productoDTO.CategoriaFK;
                    productoExistente.codigo = productoDTO.codigo;

                    db.SaveChanges();

                    return true; 

                }

                return false;

            }
            catch(Exception ex) 
            {
                Errors.handle(ex);
                return false;
            }
        }

        public bool EliminarProducto(int id)
        {
           try
            {
                Producto? producto = db.Productos.FirstOrDefault(p => p.id == id);
                
                if (producto != null)
                {
                    
                    db.Productos.Remove(producto);
                    
                    db.SaveChanges();
                    
                    return true;

                }

                return false;

            }
            catch(Exception ex)
            {
                Errors.handle(ex);
                return false;
            }
        }
    }
}
