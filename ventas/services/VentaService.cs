using Proyecto23BMBoutique2.ventas.entities;
using Proyecto23BMBoutique2.Clases;
using ProyectoBoutique23BM.Clases;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Proyecto23BMBoutique2.ventas.vistas;
using Proyecto23BMBoutique2.Auth;
using Proyecto23BMBoutique2.producto.services;

namespace Proyecto23BMBoutique2.ventas.services
{
    public class VentaService
    {
        private readonly RestauranteDataContext db = new RestauranteDataContext();
        private readonly ProductoService productoService = new ProductoService();

        public List<MejorVendedor> GetMejoresVendedores()
        {
            return this.db.Ventas
                .Include(v => v.Vendedor)
                .GroupBy(v => v.VendedorFK)
                .Select(g => new MejorVendedor
                {
                    Vendedor = g.Select( x => x.Vendedor.nombre ).FirstOrDefault()!,
                    total = g.Sum(v => v.total)
                })
                .OrderByDescending(vvt => vvt.total)
                .Take(4)
                .ToList();
        }

        public List<MejorProducto> GetMejoresProductos()
        {
            return this.db.VentasProductos
                .Include( vp => vp.Producto )
                .GroupBy(vp => vp.ProductoFK)
                .Select(g => new MejorProducto()
                {
                    nombre = g.Select( x => x.Producto.descripcion ).FirstOrDefault()!,
                    cantidad = g.Sum(vp => vp.cantidad)
                })
                .OrderByDescending(mejor_producto => mejor_producto.cantidad )
                .Take(4)
                .ToList();
        }

        public List<Venta> GetVentasPorUsuario()
        {
            return this.db.Ventas
                .Where(venta => venta.VendedorFK == Autenticacion.usuario!.id )
                .ToList();
        }
        public Venta? GetVentaById(int id)
        {
            return this.db.Ventas
                .Include(v => v.Productos)
                .ThenInclude(vp => vp.Producto)
                .FirstOrDefault(v => v.id == id);
        }

        public List<Venta> GetAllVentas()
        {
            return this.db.Ventas
                .Where( v => v.VendedorFK == Autenticacion.usuario.id )
                .Include(v => v.Productos)
                .Include(v => v.Vendedor)
                .OrderByDescending( v => v.id )
                .ToList();
        }

        public bool AddVenta(Venta venta)
        {
            try
            {
                // Limpio la relacion
                foreach ( VentaProducto producto in venta.Productos )
                {

                    int cantidad = (int)producto.cantidad;

                    productoService.RestarExistencias(producto.ProductoFK , cantidad );

                    producto.Producto = null;

                }

                venta.CreatedDate = DateTime.Now;

                this.db.Ventas.Add(venta);
                
                this.db.SaveChanges();

                return true;

            }
            catch(Exception err)
            {
                Debugger.Break();
                Errors.handle(err);
                return false;
            }
        }

        //public bool AddVentaProductos(int ventaId, List<VentaProducto> ventaProductos)
        //{
        //    try
        //    {
                
        //        Venta? venta = this.db.Ventas.FirstOrDefault(v => v.id == ventaId);

        //        if (venta == null) return false;

        //        foreach (VentaProducto ventaProducto in ventaProductos)
        //        {
        //            venta.Productos.Add(ventaProducto);
        //        }

        //        this.db.SaveChanges();

        //        return true;
        //    }
        //    catch (Exception err)
        //    {
        //        Errors.handle(err);
        //        return false;
        //    }
        //}


        public bool UpdateVenta(Venta venta)
        {
            try
            {
                Venta? existe = this.db.Ventas.Where(_venta => _venta.id == venta.id).FirstOrDefault();

                if ( existe == null ) return false;

                this.db.Ventas.Update(venta);

                this.db.SaveChanges();

                return true;

            }
            catch (Exception err)
            {
                Errors.handle(err);
                return false;
            }
        }

        public bool DeleteVenta(int id_venta)
        {
            try
            {
                Venta? existe = this.db.Ventas.Where(_venta => _venta.id == id_venta).FirstOrDefault();

                if (existe == null) return false;

                this.db.Ventas.Remove(existe);

                this.db.SaveChanges();

                return true;

            }
            catch (Exception err)
            {
                Errors.handle(err);
                return false;
            }
        }
    }

}
