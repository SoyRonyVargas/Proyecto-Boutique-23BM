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
            //UsuarioService usuarioServices = new UsuarioService();
            //UserTable.ItemsSource = usuarioServices.ObtenerTodosLosUsuarios();
        }
        private void btnAddUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtApellido.Text))
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtCorreo.Text) && !string.IsNullOrEmpty(txtContraseña.Text) && !string.IsNullOrEmpty(txtRepetirContraseña.Text) && SelectRol.SelectedItem != null)
                {
                    if (txtContraseña.Text == txtRepetirContraseña.Text)
                    {
                        UsuarioService usuarioServices = new UsuarioService();
                        Usuario usuario = new Usuario();

                        usuario.id = int.Parse(txtApellido.Text);
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

            //t.Text = usuario.id.ToString();
            txtNombre.Text = usuario.nombre.ToString();
            txtApellido.Text = usuario.apellidos.ToString();
            txtUsuario.Text = usuario.nombreUsuario.ToString();
            txtCorreo.Text = usuario.correo.ToString();
            txtContraseña.Text = usuario.password.ToString();
            txtRepetirContraseña.Text = usuario.password.ToString();
        }
    }
}
