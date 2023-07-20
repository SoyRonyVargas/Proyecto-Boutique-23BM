using ProyectoBoutique23BM.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto23BMBoutique2.entradas.entities
{
    public class Entrada_Has_Producto
    {
        [Key]
        public int id { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("Entrada")]
        public int EntradaId { get; set; }
        public Entrada Entrada { get; set; }

        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        
    }
}
