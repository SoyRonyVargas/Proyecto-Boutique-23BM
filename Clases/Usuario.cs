using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
