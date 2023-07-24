using Proyecto23BMBoutique2.rol.services;
using Proyecto23BMBoutique2.usuario.services;
using Proyecto23BMBoutique2.Vistas.VistaAdministrador.Bienvenida;
using Proyecto23BMBoutique2.Vistas.VistaAdministrador.HacerPedido;
using ProyectoBoutique23BM.Clases;
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

namespace Proyecto23BMBoutique2.usuario.vistas
{
    /// <summary>
    /// Lógica de interacción para ListarUsuarios.xaml
    /// </summary>
    public partial class ListarUsuarios : UserControl
    {
        public ListarUsuarios()
        {
            InitializeComponent();
            UpdateUserTable();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuP(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Bienvenida1 bienvenida = new Bienvenida1();
            //Close();
            bienvenida.Show();
        }
        private void HacerPedido(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HacerPedidoss hacer = new HacerPedidoss();
            //Close();
            hacer.Show();
        }
        private void PuntoVenta(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

       
        private void btnDeleteUsuario_Click(object sender, RoutedEventArgs e)
        {
            var confirmarDeleteUsuario = new MessageBoxTrueFalse("¿Deseas emliminar el usuario?");
            var result = confirmarDeleteUsuario.ShowDialog();

            if (result.HasValue && result.Value)
            {
                UsuarioService services = new UsuarioService();
                Usuario usuario = new Usuario();
                usuario = (sender as FrameworkElement).DataContext as Usuario;
                services.EliminarUsuario(usuario.id);
                UpdateUserTable();
            }
            else { }
        }
        private void btnEditUsuario_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void UpdateUserTable()
        {
            UsuarioService usuarioServices = new UsuarioService();
            UserTable.ItemsSource = usuarioServices.ObtenerTodosLosUsuarios();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.handleRouter("crearUsuario");
            }
        }
    }
}
