using Proyecto23BMBoutique2.Auth;
using ProyectoBoutique23BM.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Proyecto23BMBoutique2.Vistas.VistaAdministrador.Bienvenida
{
    /// <summary>
    /// Lógica de interacción para Bienvenida.xaml
    /// </summary>
    public partial class Bienvenida : Window
    {
        public Bienvenida()
        {
            InitializeComponent();
            txtName.Text = Autenticacion.usuario.nombre;
            txtUserName.Text = Autenticacion.usuario.nombreUsuario;
            txtHoraEntrada.Text = DateTime.Now.ToString();
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

        private void btnEditarFoto_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                ImageSource imageSource = new BitmapImage(new Uri(filename));
                Imagen.Source = imageSource;
            }
        }
    }
}
