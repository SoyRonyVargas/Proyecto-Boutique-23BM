using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto23BMBoutique2.Clases
{
    internal class Errors
    {
        public static void handle(Exception e)
        {
            MessageBox.Show("Error en la conexion a la base de datos");
            MessageBox.Show(e.Message);
        }
    }
}
