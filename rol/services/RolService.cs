using Proyecto23BMBoutique2.Clases;
using ProyectoBoutique23BM.Clases;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto23BMBoutique2.rol.services
{
    internal class RolService
    {
        private RestauranteDataContext db = new RestauranteDataContext();

        // Create
        public void AgregarRol(Rol rol)
        {
            db.Roles.Add(rol);
            db.SaveChanges();
        }

        // Read
        public List<Rol> ObtenerTodosLosRoles()
        {
            return db.Roles.ToList();
        }

        public Rol ObtenerRolPorId(int id)
        {
            return db.Roles.FirstOrDefault(r => r.id == id);
        }

        // Update
        public void ActualizarRol(Rol rol)
        {
            var rolExistente = db.Roles.FirstOrDefault(r => r.id == rol.id);
            if (rolExistente != null)
            {
                rolExistente.nombre = rol.nombre;
                db.SaveChanges();
            }
        }

        // Delete
        public void EliminarRol(int id)
        {
            var rol = db.Roles.FirstOrDefault(r => r.id == id);
            if (rol != null)
            {
                db.Roles.Remove(rol);
                db.SaveChanges();
            }
        }
    }
}
