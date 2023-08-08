using Proyecto23BMBoutique2.rol.services;
using Proyecto23BMBoutique2.usuario.services;
using ProyectoBoutique23BM.Clases;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Proyecto23BMBoutique2.usuario.vistas
{
    /// <summary>
    /// Lógica de interacción para CrearUsuario.xaml
    /// </summary>
    public partial class EditUser : UserControl
    {
        private readonly UsuarioService usuarioServices = new UsuarioService();
        private readonly RolService rolServices = new RolService();

        public EditUser(int id)
        {
            InitializeComponent();
            Idtxt.Text = id.ToString();
            GetRoles();
            MostrarDatos(id);
            
        }

        RolService services = new RolService();
        

        public void UpdateSelectRol()
        {
            SelectRol.ItemsSource = rolServices.ObtenerTodosLosRoles();
            SelectRol.DisplayMemberPath = "nombre";
            SelectRol.SelectedValuePath = "id";
        }
        public void UpdateUserTable()
        {
            //UsuarioService usuarioServices = new UsuarioService();
            //UserTable.ItemsSource = usuarioServices.ObtenerTodosLosUsuarios();
        }
        private string ConvertBitmapImageToBase64(BitmapImage bitmapImage)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Crear un codificador de imágenes y copiar la imagen en la secuencia de memoria
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(ms);

                // Convertir la secuencia de memoria a una matriz de bytes y luego a base64
                byte[] imageBytes = ms.ToArray();
                string base64Image = Convert.ToBase64String(imageBytes);

                return base64Image;
         
            }
        }
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();

                if (Imagen.Source is BitmapImage bitmapImage)
                {
                    // Convertir la imagen a base64
                    string base64Image = ConvertBitmapImageToBase64(bitmapImage);
                    usuario.Imagen = base64Image;
                }

                if ( usuario.Imagen == null )
                {
                    MessageBox.Show("El usuario debe tener una imagen");
                    return;
                }

                usuario.id = int.Parse(Idtxt.Text);
                
                usuario.nombre = txtNombre.Text;
                
                usuario.apellidos = txtApellido.Text;
                
                usuario.nombreUsuario = txtUsuario.Text;
                
                usuario.correo = txtCorreo.Text;
                
                usuario.password = txtContraseña.Password;
                
                usuario.password = txtRepetirContraseña.Password;     
                
                usuario.RolFK = int.Parse(SelectRol.SelectedValue.ToString()!);

                bool response = usuarioServices.ActualizarUsuario(usuario);

                if( response ) MessageBox.Show("Usuario actualizado correctamente");
                
                if (!response) MessageBox.Show("Error al actualizar el usuario");

                UpdateUserTable();


            }
            catch
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

            int index = rolServices.ObtenerTodosLosRoles().FindIndex(r => r.id == usuario.RolFK);
            
            SelectRol.SelectedIndex = index; 

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

