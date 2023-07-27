using Proyecto23BMBoutique2.entradas.entities;
using System.ComponentModel.DataAnnotations;
using Proyecto23BMBoutique2.Clases;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ProyectoBoutique23BM.Clases
{
    public class Producto : BaseEntity
    {
        public Producto()
        {
            Entradas = new List<Entrada>();
        }

        [Key]
        public int id { get; set; }
        public int status { get; set; }
        public string imagen { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }

        [ForeignKey("CatActual")]
        public int CategoriaFK { get; set; }
        public Categoria CatActual  { get; set; }
        public ICollection<Entrada> Entradas { get; set; }
        public ICollection<Entrada_Has_Producto> EntradaProductos { get; set; }

    }
}
