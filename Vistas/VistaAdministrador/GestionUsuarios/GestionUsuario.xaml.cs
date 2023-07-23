using Proyecto23BMBoutique2.rol.services;
using Proyecto23BMBoutique2.usuario.services;
using Proyecto23BMBoutique2.Vistas.VistaAdministrador.Bienvenida;
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
            UpdateSelectRol();
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
            Bienvenida bienvenida = new Bienvenida();
            Close();
            bienvenida.Show();

        }

        private void btnAddUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtCorreo.Text) && !string.IsNullOrEmpty(txtContraseña.Text) && !string.IsNullOrEmpty(txtRepetirContraseña.Text) && SelectRol.SelectedItem != null)
                {
                    if (txtContraseña.Text == txtRepetirContraseña.Text)
                    {
                        UsuarioService usuarioServices = new UsuarioService();
                        Usuario usuario = new Usuario();

                        usuario.id = int.Parse(txtID.Text);
                        usuario.nombre = txtNombre.Text;
                        usuario.apellidos = txtApellido.Text;
                        usuario.nombreUsuario = txtUsuario.Text;
                        usuario.correo = txtCorreo.Text;
                        usuario.password = txtContraseña.Text;
                        usuario.RolFK = int.Parse(SelectRol.SelectedValue.ToString());

                        usuarioServices.ActualizarUsuario(usuario);

                        MessageBox.Show("Usuario actualizado correctamente");
                        UpdateUserTable();
                    }
                    else MessageBox.Show("La contraseña no coincide");
                }
                else MessageBox.Show("No has ingresado todos los datos necesarios");
            }
            else
            { 
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtCorreo.Text) && !string.IsNullOrEmpty(txtContraseña.Text) && !string.IsNullOrEmpty(txtRepetirContraseña.Text) && SelectRol.SelectedItem != null)
                {
                    if (txtContraseña.Text == txtRepetirContraseña.Text)
                    {
                        UsuarioService usuarioServices = new UsuarioService();
                        Usuario usuario = new Usuario();

                        usuario.nombre = txtNombre.Text;
                        usuario.apellidos = txtApellido.Text;
                        usuario.nombreUsuario = txtUsuario.Text;
                        usuario.correo = txtCorreo.Text;
                        usuario.password = txtContraseña.Text;
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
        private void btnEditUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario = (sender as FrameworkElement).DataContext as Usuario;

            txtID.Text = usuario.id.ToString();
            txtNombre.Text = usuario.nombre.ToString();
            txtApellido.Text = usuario.apellidos.ToString();
            txtUsuario.Text = usuario.nombreUsuario.ToString();
            txtCorreo.Text = usuario.correo.ToString();
            txtContraseña.Text = usuario.password.ToString();
            txtRepetirContraseña.Text = usuario.password.ToString();
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
        public void UpdateSelectRol()
        {
            RolService rolServices = new RolService();
            SelectRol.ItemsSource = rolServices.ObtenerTodosLosRoles();
            SelectRol.DisplayMemberPath = "nombre";
            SelectRol.SelectedValuePath = "id";
        }
        public void UpdateUserTable()
        {
            UsuarioService usuarioServices = new UsuarioService();
            UserTable.ItemsSource = usuarioServices.ObtenerTodosLosUsuarios();
        }
    }
}
