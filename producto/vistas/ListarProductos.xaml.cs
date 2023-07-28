using MaterialDesignThemes.Wpf;
using Proyecto23BMBoutique2.Auth;
using Proyecto23BMBoutique2.producto.services;
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

namespace Proyecto23BMBoutique2.producto.vistas
{
    /// <summary>
    /// Lógica de interacción para ListarProductos.xaml
    /// </summary>
    public partial class ListarProductos : UserControl
    {
        public ListarProductos()
        {
            InitializeComponent();
            UpdateProductosTable();
        }
        private void MenuP(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void AñadirProductos_Click(object sender, RoutedEventArgs e)
        {

            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.handleRouter("añadirProductos");
            }

        }
        private void EditProductos_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                AutenticacionProducto.producto = (sender as FrameworkElement).DataContext as Producto;
                mainWindow.handleRouter("editarProductos");
            }
        }
        private void btnDeleteUsuario_Click(object sender, RoutedEventArgs e)
        {
            var confirmarDeleteUsuario = new MessageBoxTrueFalse("¿Deseas eliminar el producto?");
            var result = confirmarDeleteUsuario.ShowDialog();

            if (result.HasValue && result.Value)
            {
                ProductoService services = new ProductoService();
                Producto producto = new Producto();
                producto = (sender as FrameworkElement).DataContext as Producto;
                services.EliminarProducto(producto.id);
                UpdateProductosTable();
            }
            else { }
        }
        public void UpdateProductosTable()
        {
            ProductoService productoService = new ProductoService();
            ProductosTable.ItemsSource = productoService.ObtenerTodosLosProductos();
        }

    }
}
