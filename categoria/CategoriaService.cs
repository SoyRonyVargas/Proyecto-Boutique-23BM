using Proyecto23BMBoutique2.Clases;
using ProyectoBoutique23BM.Clases;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto23BMBoutique2.categoria.services
{
    internal class CategoriaService
    {
        private RestauranteDataContext db = new RestauranteDataContext();

        // Create
        //public void AgregarCategoria(Categoria categoria)
        //{
        //    db.Categorias.Add(categoria);
        //    db.SaveChanges();
        //}

        //// Read
        public List<Categoria> ObtenerTodasLasCategorias()
        {
            return db.Categorias.ToList();
        }

        public Categoria ObtenerCategoriaPorId(int id)
        {
            return db.Categorias.FirstOrDefault(c => c.id == id);
        }

        //// Update
        //public void ActualizarCategoria(Categoria categoria)
        //{
        //    var categoriaExistente = db.Categorias.FirstOrDefault(c => c.id == categoria.id);
        //    if (categoriaExistente != null)
        //    {
        //        categoriaExistente.nombre = categoria.nombre;
        //        db.SaveChanges();
        //    }
        //}

        //// Delete
        //public void EliminarCategoria(int id)
        //{
        //    var categoria = db.Categorias.FirstOrDefault(c => c.id == id);
        //    if (categoria != null)
        //    {
        //        db.Categorias.Remove(categoria);
        //        db.SaveChanges();
        //    }
        //}
    }
}
