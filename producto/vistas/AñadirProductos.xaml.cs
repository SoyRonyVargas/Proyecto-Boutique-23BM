using Proyecto23BMBoutique2.Auth;
using Proyecto23BMBoutique2.categoria.services;
using Proyecto23BMBoutique2.Clases;
using Proyecto23BMBoutique2.producto.services;
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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto23BMBoutique2.producto.vistas
{
    /// <summary>
    /// Lógica de interacción para AñadirProductos.xaml
    /// </summary>
    public partial class AñadirProductos : UserControl
    {
        public AñadirProductos()
        {
            InitializeComponent();
            UpdateSelectCategoria();
        }

        private ProductoService services = new ProductoService();
        private Producto producto = new Producto();

        private void btnEditarImagen_Click(object sender, RoutedEventArgs e)
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
                txtImagen.Text = filename;
            }
        }
        private void btnAddProducto_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (!string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtStatus.Text) && !string.IsNullOrEmpty(txtImagen.Text) && SelectCategoria.SelectedItem != null)
                {
                    producto.descripcion = txtDescripcion.Text;
                    producto.codigo = txtCodigo.Text;
                    producto.imagen = txtImagen.Text;
                    producto.status = int.Parse(txtStatus.Text);
                    producto.CategoriaFK = int.Parse(SelectCategoria.SelectedValue.ToString());
                    producto.existencias = 0;

                    services.AgregarProducto(producto);
                    MessageBox.Show("Producto añadido correctamente");
                    if (App.Current.MainWindow is MainWindow mainWindow)
                    {
                        mainWindow.handleRouter("listarProductos");
                    }
                }
                else MessageBox.Show("No has ingresado todos los datos necesarios");
            }
            catch (Exception ex) { Errors.handle(ex); }
            

        }
        public void UpdateSelectCategoria()
        {
            CategoriaService service = new CategoriaService();
            SelectCategoria.ItemsSource = service.ObtenerTodasLasCategorias();
            SelectCategoria.DisplayMemberPath = "nombre";
            SelectCategoria.SelectedValuePath = "id";
        }

    }
}
