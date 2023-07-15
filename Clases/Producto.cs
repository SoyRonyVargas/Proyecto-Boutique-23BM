using Proyecto23BMBoutique2.Clases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoBoutique23BM.Clases
{
    public class Producto : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public int status { get; set; }
        public string imagen { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        
        [ForeignKey("Categoria")]
        public int CategoriaFK { get; set; }
        public Categoria Categoria  { get; set; }

    }
}
