using Proyecto23BMBoutique2.ventas.entities;
using Proyecto23BMBoutique2.Clases;
using ProyectoBoutique23BM.Clases;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Proyecto23BMBoutique2.ventas.services
{
    public class VentaService
    {
        private readonly RestauranteDataContext db = new RestauranteDataContext();

        public Venta? GetVentaById(int id)
        {
            return this.db.Ventas
                .Include( v => v.Productos )
                .ThenInclude(vp => vp.Producto)
                .FirstOrDefault(v => v.id == id);
        }

        public List<Venta> GetAllVentas()
        {
            return this.db.Ventas.ToList();
        }

        public Venta? AddVenta(Venta venta)
        {
            try
            {
                this.db.Ventas.Add(venta);
                
                this.db.SaveChanges();

                return venta;

            }
            catch(Exception err)
            {
                Errors.handle(err);
                return null;
            }
        }

        public bool AddVentaProductos(int ventaId, List<VentaProducto> ventaProductos)
        {
            try
            {
                
                Venta venta = this.db.Ventas.FirstOrDefault(v => v.id == ventaId);

                Debugger.Break();

                if (venta == null)
                    return false;

                foreach (VentaProducto ventaProducto in ventaProductos)
                {
                    venta.Productos.Add(ventaProducto);
                }

                this.db.SaveChanges();

                return true;
            }
            catch (Exception err)
            {
                Errors.handle(err);
                return false;
            }
        }


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
