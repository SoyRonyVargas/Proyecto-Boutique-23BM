using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProyectoBoutique23BM.Clases;

namespace Proyecto23BMBoutique2.ventas.entities
{
    public class VentaProducto
    {
        [Key]
        public int id { get; set; }
        public int status { get; set; }
        public double cantidad { get; set; }
        public double precio_pieza { get; set; }
        public double importe { get; set; }
        public double iva { get; set; }
        public double total { get; set; }

        [ForeignKey("Venta")]
        public int VentaFK { get; set; }
        public Venta Venta { get; set; }

        [ForeignKey("Producto")]
        public int ProductoFK { get; set; }
        public Producto Producto { get; set; }

    }
}
