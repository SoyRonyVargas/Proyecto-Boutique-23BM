using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto23BMBoutique2.router
{
    public class Route
    {
        public string Path { get; set; }
        public string Nombre { get; set; }
        public Type WindowType { get; set; }

        public Route(string path, string nombre , Type windowType)
        {
            Path = path;
            Nombre = nombre;
            WindowType = windowType;
        }
    }
}
