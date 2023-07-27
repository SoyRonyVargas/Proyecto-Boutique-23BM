using Proyecto23BMBoutique2.Clases;
using Proyecto23BMBoutique2.rol.services;
using Proyecto23BMBoutique2.usuario.services;
using ProyectoBoutique23BM.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Lógica de interacción para CrearUsuario.xaml
    /// </summary>
    public partial class EditUser : UserControl
    {
        private readonly UsuarioService usuarioServices = new UsuarioService();

        public EditUser(int id)
        {
            InitializeComponent();
            MostrarDatos(id);
            Idtxt.Text = id.ToString();
            GetRoles();
            
        }

        RolService services = new RolService();
        

        public void UpdateSelectRol()
        {
            RolService rolServices = new RolService();
            SelectRol.ItemsSource = rolServices.ObtenerTodosLosRoles();
            SelectRol.DisplayMemberPath = "nombre";
            SelectRol.SelectedValuePath = "id";
        }
        public void UpdateUserTable()
        {
            //UsuarioService usuarioServices = new UsuarioService();
            //UserTable.ItemsSource = usuarioServices.ObtenerTodosLosUsuarios();
        }
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.id = int.Parse(Idtxt.Text);
                usuario.nombre = txtNombre.Text;
                usuario.apellidos = txtApellido.Text;
                usuario.nombreUsuario = txtUsuario.Text;
                usuario.correo = txtCorreo.Text;
                usuario.password = txtContraseña.Password;
                usuario.password = txtRepetirContraseña.Password;     
                usuario.RolFK = int.Parse(SelectRol.SelectedValue.ToString());
                usuario.Imagen = usuarioServices.ConvertImageToBase64(RutaImagen.Text);
                usuarioServices.ActualizarUsuario(usuario);
                MessageBox.Show("Usuario actualizado correctamente");
                UpdateUserTable();

            }catch (Exception ex)
            {
                MessageBox.Show("Porfavor Ingrese todos los valores");
            }

        }
        public void GetRoles()
        {
            SelectRol.ItemsSource = services.GetRoles();
            SelectRol.DisplayMemberPath = "nombre";
            SelectRol.SelectedValuePath = "id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Establecer filtro para aceptar todos los archivos de imagen
            dlg.Filter = "All Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|JPEG Files|*.jpg;*.jpeg|PNG Files|*.png|BMP Files|*.bmp|GIF Files|*.gif";
            // Mostrar el cuadro de diálogo de selección de archivo
            Nullable<bool> result = dlg.ShowDialog();
            // Obtener el nombre del archivo seleccionado y mostrarlo en el control Image
            if (result == true)
            {
                string filename = dlg.FileName;
                RutaImagen.Text = filename.ToString();
                ImageSource imageSource = new BitmapImage(new Uri(filename));
                Imagen.Source = imageSource;
            }
        }
        private void MostrarDatos(int id)
        {
            Usuario? usuario = usuarioServices.ObtenerUsuarioPorId(id);
            txtNombre.Text = usuario.nombre;
            txtApellido.Text = usuario.apellidos;
            txtUsuario.Text = usuario.nombreUsuario;
            txtCorreo.Text = usuario.correo;
            txtContraseña.Password = usuario.password;
            txtRepetirContraseña.Password = usuario.password;
            MostrarImagen(usuario.id);
            RolService rolServices = new RolService();
            Rol rolSeleccionado = rolServices.ObtenerRolPorId(usuario.id);
            SelectRol.SelectedItem = rolSeleccionado;

        }
        private void MostrarImagen(int id)
        {
            Usuario? usuario = usuarioServices.ObtenerUsuarioPorId(id);
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

