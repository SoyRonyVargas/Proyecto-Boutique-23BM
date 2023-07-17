using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoBoutique23BM.Clases;

namespace Proyecto23BMBoutique2.ventas.entities
{
    public class Venta : BaseEntity
    {
        public Venta()
        {
            Productos = new List<VentaProducto>();
        }
        [Key]
        public int id { get; set; }
        public int status { get; set; }
        public double importe { get; set; }
        public double iva { get; set; }
        public double total { get; set; }
        public ICollection<VentaProducto> Productos { get; set; }

        [ForeignKey("Vendedor")]
        public int VendedorFK { get; set; }
        public Usuario Vendedor { get; set; }

    }
}
