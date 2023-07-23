
using Proyecto23BMBoutique2.Vistas.VistaAdministrador.Bienvenida;
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

namespace Proyecto23BMBoutique2.Vistas.VistaAdministrador.HacerPedido
{
    /// <summary>
    /// Lógica de interacción para HacerPedido.xaml
    /// </summary>
    public partial class HacerPedidoss : Window
    {
        public HacerPedidoss()
        {
            InitializeComponent();
        }
        private void GestionUser(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GestionUsuario ges = new GestionUsuario();
            Close();
            ges.Show();
        }
        private void PuntoVenta(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            

        }
        private void Inventario(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }
        private void MenuP(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            Bienvenida1 bienvenida = new Bienvenida1();
            Close();
            bienvenida.Show();
             
        }

        private void EditItem (object sender , RoutedEventArgs e)
        {

        }
        private void EliminaPedido(object sender, RoutedEventArgs e)
        {

        }
    }
}
