using Proyecto23BMBoutique2.Auth;
using Proyecto23BMBoutique2.categoria.services;
using Proyecto23BMBoutique2.Clases;
using Proyecto23BMBoutique2.producto.services;
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

namespace Proyecto23BMBoutique2.producto.vistas
{
    /// <summary>
    /// Lógica de interacción para EditarProducto.xaml
    /// </summary>
    public partial class EditarProductos : UserControl
    {
        public EditarProductos()
        {
            InitializeComponent();
            UpdateSelectCategoria();
            UpdateTextBox();
        }
        
        private ProductoService productoServices = new ProductoService();
        private CategoriaService categoriaServices = new CategoriaService();
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
        private void btnEditProducto_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtStatus.Text) && !string.IsNullOrEmpty(txtImagen.Text) && SelectCategoria.SelectedItem != null)
            {
                producto.id = AutenticacionProducto.producto.id;
                producto.descripcion = txtDescripcion.Text;
                producto.codigo = txtCodigo.Text;
                producto.imagen = txtImagen.Text;
                producto.status = int.Parse(txtStatus.Text);
                producto.CategoriaFK = int.Parse(SelectCategoria.SelectedValue.ToString());

                productoServices.ActualizarProducto(producto);

                MessageBox.Show("Información del producto actualizado correctamente");
                if (App.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.handleRouter("listarProductos");
                }
            }
            else MessageBox.Show("No has ingresado todos los datos necesarios");
        }

        public void UpdateTextBox()
        {
            Categoria categorita;
            categorita = categoriaServices.ObtenerCategoriaPorId(AutenticacionProducto.producto.CategoriaFK);

            txtDescripcion.Text = AutenticacionProducto.producto.descripcion.ToString();
            txtCodigo.Text = AutenticacionProducto.producto.codigo.ToString();
            txtStatus.Text = AutenticacionProducto.producto.status.ToString();
            txtImagen.Text = AutenticacionProducto.producto.imagen.ToString();
            AsignarValorAlComboBox(categorita.nombre);
        }
        public void UpdateSelectCategoria()
        {
            CategoriaService service = new CategoriaService();
            SelectCategoria.ItemsSource = service.ObtenerTodasLasCategorias();
            SelectCategoria.DisplayMemberPath = "nombre";
            SelectCategoria.SelectedValuePath = "id";
        }

        private void AsignarValorAlComboBox(string nombreSeleccionado)
        {
            // Buscamos el objeto Categoria en el ComboBox cuyo atributo "nombre" coincida con la cadena "nombreSeleccionado"
            Categoria itemSeleccionado = SelectCategoria.Items.OfType<Categoria>().FirstOrDefault(item => item.nombre == nombreSeleccionado);

            // Aqui seleccionamos el objeto que encontramos en el comboBox
            SelectCategoria.SelectedItem = itemSeleccionado;
        }

    }
}
