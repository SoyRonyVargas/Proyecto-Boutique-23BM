using System.ComponentModel.DataAnnotations;

namespace ProyectoBoutique23BM.Clases
{
    public class Producto : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int existencias_iniciales { get; set; }
        public int existencias_restantes { get; set; }
    }
}
