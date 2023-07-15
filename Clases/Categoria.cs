using ProyectoBoutique23BM.Clases;
using System.ComponentModel.DataAnnotations;


namespace Proyecto23BMBoutique2.Clases
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
    }
}
