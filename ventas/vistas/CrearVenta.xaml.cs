using Proyecto23BMBoutique2.producto.services;
using Proyecto23BMBoutique2.ventas.entities;
using ProyectoBoutique23BM.Clases;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Proyecto23BMBoutique2.ventas.vistas
{
    /// <summary>
    /// Lógica de interacción para CrearVenta.xaml
    /// </summary>
    public partial class CrearVenta : UserControl
    {

        private List<VentaProducto> productosSeleccionados = new List<VentaProducto>();
        private readonly ProductoService productoService = new ProductoService();
        public CrearVenta()
        {
            InitializeComponent();
        }

        public void handle()
        {
            var x = new MainWindow();
            x.handleRouter("");
        }

        private void CardProducto_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            //int codigo = int.Parse(input_codigo.Text);

            //if (codigo) return;

            //this.productoService.ObtenerProductoPorId(codigo);

        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            string nombreProducto = input_nombre_producto.Text;

            List<Producto> productosPorNombre = this.productoService.ObtenerProductosPorNombre(nombreProducto);

            comboProductos.ItemsSource = productosPorNombre;
            comboProductos.DisplayMemberPath = "descripcion";
            comboProductos.SelectedIndex = 0;

        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {

            VentaProducto productoNuevo = new VentaProducto();

            Producto productoSeleccionado = comboProductos.SelectedItem as Producto;

            productoNuevo.ProductoFK = productoSeleccionado!.id;

            productosSeleccionados.Add(productoNuevo);

            gridProductosSeleccionados.ItemsSource = productosSeleccionados;

        }
    }
}
