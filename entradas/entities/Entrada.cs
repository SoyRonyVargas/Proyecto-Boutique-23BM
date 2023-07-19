using System.ComponentModel.DataAnnotations.Schema;
using Proyecto23BMBoutique2.proveedores.entities;
using System.ComponentModel.DataAnnotations;
using ProyectoBoutique23BM.Clases;
using System.Collections.Generic;

namespace Proyecto23BMBoutique2.entradas.entities
{
    public class Entrada : BaseEntity
    {
        public Entrada()
        {
            //EntradaProductos = new List<Entrada_Has_Producto>();
        }

        [Key]
        public int id { get; set; }
        public int status { get; set; }
        public double importe { get; set; }
        public double iva { get; set; }
        public double total { get; set; }

        [ForeignKey("Proveedor")]
        public int ProveedorFK { get; set; }
        public Proveedor Proveedor { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioFK { get; set; }
        // quien crea la entrada
        public Usuario Usuario { get; set; }
        //public ICollection<Entrada_Has_Producto>? EntradaProductos { get; set; }
        //public ICollection<Producto> Productos { get; set; }

    }
}
