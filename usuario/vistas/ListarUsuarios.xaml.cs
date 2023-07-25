using Proyecto23BMBoutique2.rol.services;
using Proyecto23BMBoutique2.usuario.services;
using Proyecto23BMBoutique2.ventas.vistas;
using Proyecto23BMBoutique2.Vistas.VistaAdministrador.Bienvenida;
using Proyecto23BMBoutique2.Vistas.VistaAdministrador.HacerPedido;
using ProyectoBoutique23BM.Clases;
using System;
using System.Collections.Generic;
using System.IO;
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
            Usuario usuario = (sender as FrameworkElement).DataContext as Usuario;
            int id = usuario.id;

            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.handleRouterWithParament("EditUser",id);
            }
            
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
        private void btnVerFoto_Click(object sender, RoutedEventArgs e)
        {
            UsuarioService services = new UsuarioService();
            Usuario usuario = new Usuario();
            usuario = (sender as FrameworkElement).DataContext as Usuario;
            // Obtener el usuario autenticado o el texto base64 de la imagen desde algún lugar
            string base64String = usuario.Imagen;

            // Convertir el texto base64 a BitmapImage
            BitmapImage bitmapImage = ConvertBase64ToBitmapImage(base64String);

            if (bitmapImage != null)
            {
                // Asignar la imagen al control Image dentro del Popup
                Imagen.Source = bitmapImage;


            }
        }
        public static BitmapImage ConvertBase64ToBitmapImage(string base64String)
        {
            try
            {
                // Convierte el texto base64 en un arreglo de bytes
                byte[] imageBytes = Convert.FromBase64String(base64String);

                // Crea un BitmapImage
                BitmapImage bitmapImage = new BitmapImage();

                // Crea un MemoryStream para convertir el arreglo de bytes en una imagen
                using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                {
                    // Carga el BitmapImage desde el MemoryStream
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = memoryStream;
                    bitmapImage.EndInit();
                }

                return bitmapImage;
            }
            catch (Exception ex)
            {
                // Manejar excepciones si es necesario
                Console.WriteLine("Error al convertir el texto base64 a BitmapImage: " + ex.Message);
                return null;
            }
        }
    }
}
