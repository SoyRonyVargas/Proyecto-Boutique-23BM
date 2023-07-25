using Proyecto23BMBoutique2.rol.services;
using Proyecto23BMBoutique2.usuario.services;
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
    /// Lógica de interacción para CrearUsuario.xaml
    /// </summary>
    public partial class CrearUsuario : UserControl
    {
        public CrearUsuario()
        {
            InitializeComponent();
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
        private void btnAddUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtApellido.Text))
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtCorreo.Text) && !string.IsNullOrEmpty(txtContraseña.Password) && !string.IsNullOrEmpty(txtRepetirContraseña.Password) && SelectRol.SelectedItem != null)
                {
                    if (txtContraseña.Password == txtRepetirContraseña.Password)
                    {
                        UsuarioService usuarioServices = new UsuarioService();
                        Usuario usuario = new Usuario();
                        usuario.nombre = txtNombre.Text;
                        usuario.apellidos = txtApellido.Text;
                        usuario.nombreUsuario = txtUsuario.Text;
                        usuario.correo = txtCorreo.Text;
                        usuario.password = txtContraseña.Password;
                        usuario.RolFK = int.Parse(SelectRol.SelectedValue.ToString());
                        usuario.Imagen = usuarioServices.ConvertImageToBase64(RutaImagen.Text);

                        usuarioServices.AgregarUsuario(usuario);

                        MessageBox.Show("Usuario actualizado correctamente");
                        UpdateUserTable();
                    }
                    else MessageBox.Show("La contraseña no coincide");
                }
                else MessageBox.Show("No has ingresado todos los datos necesarios");
            }
            else
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtCorreo.Text) && !string.IsNullOrEmpty(txtContraseña.Password) && !string.IsNullOrEmpty(txtRepetirContraseña.Password) && SelectRol.SelectedItem != null)
                {
                    if (txtContraseña.Password == txtRepetirContraseña.Password)
                    {
                        UsuarioService usuarioServices = new UsuarioService();
                        Usuario usuario = new Usuario();

                        usuario.nombre = txtNombre.Text;
                        usuario.apellidos = txtApellido.Text;
                        usuario.nombreUsuario = txtUsuario.Text;
                        usuario.correo = txtCorreo.Text;
                        usuario.password = txtContraseña.Password;
                        usuario.RolFK = int.Parse(SelectRol.SelectedValue.ToString());

                        usuarioServices.AgregarUsuario(usuario);

                        MessageBox.Show("Usuario añadido correctamente");
                        UpdateUserTable();
                    }
                    else MessageBox.Show("La contraseña no coincide");
                }
                else MessageBox.Show("No has ingresado todos los datos necesarios");
            }
        }
        private void EditarUser(Usuario request)
        {
            UsuarioService usuarioServices = new UsuarioService();
            Usuario usuario = new Usuario();
            
            //t.Text = usuario.id.ToString();
            txtNombre.Text = usuario.nombre.ToString();
            txtApellido.Text = usuario.apellidos.ToString();
            txtUsuario.Text = usuario.nombreUsuario.ToString();
            txtCorreo.Text = usuario.correo.ToString();
            txtContraseña.Password = usuario.password.ToString();
            txtRepetirContraseña.Password = usuario.password.ToString();
            usuarioServices.ActualizarUsuario(usuario);
            MessageBox.Show("Usuario actualizado correctamente");
            UpdateUserTable();
            
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


    }
}
