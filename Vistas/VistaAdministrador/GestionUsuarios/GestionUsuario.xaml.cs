using Proyecto23BMBoutique2.Vistas.VistaAdministrador.Bienvenida;
using Proyecto23BMBoutique2.Vistas.VistaAdministrador.HacerPedido;
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
using System.Windows.Shapes;

namespace Proyecto23BMBoutique2.Vistas
{
    /// <summary>
    /// Lógica de interacción para AgregarProducto.xaml
    /// </summary>
    public partial class GestionUsuario : Window
    {
        public GestionUsuario()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void EditItem (object sender, RoutedEventArgs e)
        {

        }
        private void MenuP(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Bienvenida1 bienvenida = new Bienvenida1();
            Close();
            bienvenida.Show();
        }
        private void HacerPedido(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HacerPedidoss hacer = new HacerPedidoss();
            Close();
            hacer.Show();
        }
        private void PuntoVenta(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
        private void Inventario(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

    }
}
