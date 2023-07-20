using Microsoft.EntityFrameworkCore;
using Proyecto23BMBoutique2.Clases;
using ProyectoBoutique23BM.Clases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto23BMBoutique2.usuario.services
{
    internal class UsuarioService
    {
        private RestauranteDataContext db = new RestauranteDataContext();

        // Verifica si un usuario está autenticado.
        // Devuelve true si el usuario está autenticado, de lo contrario devuelve false.
        public bool AutenticarUsuario(string usuario, string password)
        {
            try
            {
                // Obtener el usuario por nombre de usuario
                Usuario? user = this.ObtenerUsuarioPorNombreUsuario(usuario);

                if (user == null) return false;

                // Comparar la contraseña proporcionada con la contraseña del usuario

                return user.password == password;
            }
            catch
            {
                return false;
            }
        }

        // Create
        // Agrega un nuevo usuario a la base de datos.
        // Devuelve true si se agrega correctamente, de lo contrario devuelve false.

        public void PersistirUsuario()
        {

        }

        public bool AgregarUsuario(Usuario usuario)
        {
            try
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Read
        // Obtiene una lista de todos los usuarios.
        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            try
            {
                return db.Usuarios.Include(x=>x.Rol).ToList(); 
            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return new List<Usuario> { };
            }
        }

        // Obtiene un usuario por su nombre de usuario.
        public Usuario? ObtenerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            try
            {
                Usuario? usuario = db.Usuarios.Where(p => p.nombreUsuario == nombreUsuario).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return null;
            }
        }

        // Obtiene un usuario por su ID.
        public Usuario? ObtenerUsuarioPorId(int id)
        {
            try
            {
                Usuario? usuario = db.Usuarios.FirstOrDefault(p => p.id == id);
                return usuario;
            }
            catch (Exception ex)
            {
                Errors.handle(ex);
                return null;
            }
        }

        // Update
        // Actualiza los datos de un usuario existente en la base de datos.
        // Devuelve true si se actualiza correctamente, de lo contrario devuelve false.
        public bool ActualizarUsuario(Usuario usuarioDTO)
        {
            try
            {
                Usuario? usuarioExistente = db.Usuarios.FirstOrDefault(p => p.id == usuarioDTO.id);

                if (usuarioExistente != null)
                {
                    // Actualizar los datos del usuario
                    usuarioExistente.apellidos = usuarioDTO.apellidos;
                    usuarioExistente.password = usuarioDTO.password;
                    usuarioExistente.correo = usuarioDTO.correo;
                    usuarioExistente.nombre = usuarioDTO.nombre;
                    usuarioExistente.RolFK = usuarioDTO.RolFK;

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

        // Elimina un usuario de la base de datos por su ID.
        // Devuelve true si se elimina correctamente, de lo contrario devuelve false.
        public bool EliminarUsuario(int id)
        {
            try
            {
                Usuario? usuario = db.Usuarios.FirstOrDefault(p => p.id == id);

                if (usuario != null)
                {
                    // Eliminar el usuario
                    db.Usuarios.Remove(usuario);
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
