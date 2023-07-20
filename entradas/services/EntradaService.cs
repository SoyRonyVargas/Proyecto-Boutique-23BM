using Proyecto23BMBoutique2.Clases;
using ProyectoBoutique23BM.Clases;
using System.Collections.Generic;
using System.Linq;
using System;
using Proyecto23BMBoutique2.entradas.entities;
using Microsoft.EntityFrameworkCore;

namespace Proyecto23BMBoutique2.entrada.services
{
    internal class EntradaService
    {
        private RestauranteDataContext db = new RestauranteDataContext();

        // Create
        public bool AgregarEntrada(Entrada entrada)
        {
            try
            {
                
                db.Entradas.Add(entrada);
                
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
        public List<Entrada> ObtenerTodasLasEntradas()
        {
            try
            {
                return db.Entradas
                    .Include( entrada => entrada.EntradaProductos )!
                    .ThenInclude( ep => ep.Producto )
                    .Include(entrada => entrada.Proveedor)
                    .Include(entrada => entrada.Usuario)
                    .ToList();   
            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return new List<Entrada> { };
            }
        }

        public Entrada? ObtenerEntradaPorId(int id)
        {
            try
            {
                
                Entrada? entrada = db.Entradas
                    .Include(entrada => entrada.EntradaProductos)!
                    .ThenInclude(ep => ep.Producto)
                    .Include(entrada => entrada.Proveedor)
                    .Include(entrada => entrada.Usuario)
                    .FirstOrDefault(e => e.id == id);

                return entrada;

            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return null;
            }
        }

        // Update
        public bool ActualizarEntrada(Entrada entradaDTO)
        {
            try
            {
                
                Entrada? entradaExistente = db.Entradas.FirstOrDefault(e => e.id == entradaDTO.id);

                if (entradaExistente == null) return false;

                entradaExistente.status = entradaDTO.status;
                entradaExistente.importe = entradaDTO.importe;
                entradaExistente.iva = entradaDTO.iva;
                entradaExistente.total = entradaDTO.total;
                entradaExistente.ProveedorFK = entradaDTO.ProveedorFK;
                entradaExistente.UsuarioFK = entradaDTO.UsuarioFK;

                db.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return false;
            }
        }

        public bool EliminarEntrada(int id)
        {
            try
            {
                Entrada? entrada = db.Entradas.FirstOrDefault(e => e.id == id);
                
                if (entrada == null) return false;

                db.Entradas.Remove(entrada);
                
                db.SaveChanges();
                
                return true;

            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return false;
            }
        }
    }
}
