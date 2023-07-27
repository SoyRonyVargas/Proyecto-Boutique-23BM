using Proyecto23BMBoutique2.entrada.services;
using Proyecto23BMBoutique2.entradas.entities;
using Proyecto23BMBoutique2.ventas.entities;
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
        private readonly EntradaService entradaService = new EntradaService();
        public ListarCompras()
        {
            InitializeComponent();
            mounted();
        }
        private void mounted()
        {
            List<Entrada> entradas = entradaService.ObtenerTodasLasEntradas();
            gridEntradas.ItemsSource = entradas;
        }

        private void handleVerEntrada(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;

            if (sender is Button)
            {
                if (App.Current.MainWindow is MainWindow mainWindow)
                {

                    Entrada? entrada = button!.DataContext as Entrada;

                    mainWindow.handleRouter("editarEntrada", entrada!.id);

                }
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void AñadirCompra_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.handleRouter("crearEntrada");
            }
        }
    }
}
