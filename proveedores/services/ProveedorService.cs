using Proyecto23BMBoutique2.proveedores.entities;
using Proyecto23BMBoutique2.Clases;
using ProyectoBoutique23BM.Clases;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Proyecto23BMBoutique2.proveedor.services
{
    internal class ProveedorService
    {
        private RestauranteDataContext db = new RestauranteDataContext();

        // Create
        public bool AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                db.Proveedores.Add(proveedor);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return false;
            }
        }

        // Read
        public List<Proveedor> ObtenerTodosLosProveedores()
        {
            try
            {
                return db.Proveedores.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return new List<Proveedor> { };
            }
        }

        public Proveedor? ObtenerProveedorPorId(int id)
        {
            try
            {
                Proveedor? proveedor = db.Proveedores.FirstOrDefault(p => p.id == id);
                return proveedor;
            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return null;
            }
        }

        // Update
        public bool ActualizarProveedor(Proveedor proveedorDTO)
        {
            try
            {
                Proveedor? proveedorExistente = db.Proveedores.FirstOrDefault(p => p.id == proveedorDTO.id);

                    Debugger.Break();
                if (proveedorExistente != null)
                {
                    proveedorExistente.nombre = proveedorDTO.nombre;
                    proveedorExistente.contacto = proveedorDTO.contacto;
                    proveedorExistente.empresa = proveedorDTO.empresa;
                    proveedorExistente.direccion = proveedorDTO.direccion;
                    proveedorExistente.telefono = proveedorDTO.telefono;
                    proveedorExistente.correo_electronico = proveedorDTO.correo_electronico;
                    proveedorExistente.status = proveedorDTO.status;

                    db.Proveedores.Update(proveedorExistente);


                    db.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return false;
            }
        }

        public bool EliminarProveedor(int id)
        {
            try
            {
                Proveedor? proveedor = db.Proveedores.FirstOrDefault(p => p.id == id);

                if (proveedor != null)
                {
                    db.Proveedores.Remove(proveedor);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return false;
            }
        }
    }
}
