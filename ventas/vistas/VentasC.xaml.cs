using Proyecto23BMBoutique2.ventas.entities;
using Proyecto23BMBoutique2.ventas.services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Proyecto23BMBoutique2.ventas.vistas
{
    /// <summary>
    /// Lógica de interacción para VentasC.xaml
    /// </summary>
    public partial class VentasC : UserControl
    {

        private readonly VentaService ventaService = new VentaService();

        public VentasC()
        {
            InitializeComponent();
            mounted();
        }

        private void mounted()
        {
            List<Venta> ventas = this.ventaService.GetAllVentas();
            gridVentas.ItemsSource = ventas;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                // Llama a la función handleClick en MainWindow
                mainWindow.handleRouter("crearVenta");
            }
            //DataContext = new CrearVenta();
            //Debugger.Break();
        }
    }
}
