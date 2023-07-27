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

namespace Proyecto23BMBoutique2.entradas.vistas
{
    /// <summary>
    /// Lógica de interacción para ListarCompras.xaml
    /// </summary>
    public partial class ListarCompras : UserControl
    {
        public ListarCompras()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void AñadirCompra_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.handleRouter("ReporteCompra");
            }
        }
    }
}
