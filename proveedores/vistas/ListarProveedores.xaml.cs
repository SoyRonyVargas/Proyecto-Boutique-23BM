using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto23BMBoutique2.proveedores.vistas
{
    /// <summary>
    /// Lógica de interacción para ListarProveedores.xaml
    /// </summary>
    public partial class ListarProveedores : UserControl
    {
        public ListarProveedores()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                // Llama a la función handleClick en MainWindow
                mainWindow.handleRouter("Crearproveedor");
            }
        }
    }
}
