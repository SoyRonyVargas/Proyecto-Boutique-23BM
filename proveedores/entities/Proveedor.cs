using System.ComponentModel.DataAnnotations;
using ProyectoBoutique23BM.Clases;

namespace Proyecto23BMBoutique2.proveedores.entities
{
    public class Proveedor : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string contacto { get; set; }
        public string empresa { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo_electronico { get; set; }
        public int status { get; set; }

    }

}
