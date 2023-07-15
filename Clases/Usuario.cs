using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Proyecto23BMBoutique2.Clases;


namespace ProyectoBoutique23BM.Clases
{
    public class Usuario : BaseEntity
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public string? password { get; set; }
        public string correo { get; set; }
        public string nombreUsuario { get; set; }

        [ForeignKey("Rol")]
        public int RolFK { get; set; }
        public Rol Rol { get; set; }
    }
}
