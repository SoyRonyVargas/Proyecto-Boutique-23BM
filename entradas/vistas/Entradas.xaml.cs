using Proyecto23BMBoutique2.proveedores.entities;
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

namespace Proyecto23BMBoutique2.entradas.vistas
{
    /// <summary>
    /// Lógica de interacción para Entradas.xaml
    /// </summary>
    public partial class Entradas : Window
    {
        // Lista para almacenar los productos agregados a la entrada
        private List<ProductoEntrada> productosEntrada = new List<ProductoEntrada>();

        public Entradas()
        {
            InitializeComponent();
            CargarTiposDocumento();
        }

        // Método para cargar los tipos de documento en el ComboBox
        private void CargarTiposDocumento()
        {
            // Aquí deberías cargar los tipos de documento desde la base de datos
            List<string> tiposDocumento = new List<string>
            {
                "TipoDoc1",
                "TipoDoc2",
                "TipoDoc3"
            };
            cbotipodocumento.ItemsSource = tiposDocumento;
        }

        // Evento para buscar un proveedor
        private void btnbuscarproveedor_Click(object sender, RoutedEventArgs e)
        {
            // implementar la lógica para buscar y mostrar los detalles del proveedor
            // Puedes mostrar los detalles en los TextBox correspondientes
        }

        // Evento para buscar un producto
        private void btnbuscarproducto_Click(object sender, RoutedEventArgs e)
        {
            // implementar la lógica para buscar y mostrar los detalles del producto
            // Puedes mostrar los detalles en los TextBox correspondientes
        }

        // Evento para agregar un producto a la entrada
        private void btnagregarproducto_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los datos del producto desde los TextBox
            int idProducto = int.Parse(txtidproducto.Text);
            string nombreProducto = txtproducto.Text;
            double precioCompra = double.Parse(txtpreciocompra.Text);
            double precioVenta = double.Parse(txtprecioventa.Text);
            int cantidad = int.Parse(txtcantidad.Text);

            // Calcular el subtotal
            double subtotal = precioCompra * cantidad;

            // Crear un objeto ProductoEntrada y agregarlo a la lista de productosEntrada
            ProductoEntrada productoEntrada = new ProductoEntrada
            {
                IdProducto = idProducto,
                NombreProducto = nombreProducto,
                PrecioCompra = precioCompra,
                PrecioVenta = precioVenta,
                Cantidad = cantidad,
                SubTotal = subtotal
            };

            productosEntrada.Add(productoEntrada);

            // Actualizar el DataGrid con los productos de la entrada
            dtvdata.ItemsSource = null;
            dtvdata.ItemsSource = productosEntrada;

            // Calcular y mostrar el total a pagar
            double totalPagar = CalcularTotalPagar();
            txttotalpagar.Text = totalPagar.ToString();
        }

        // Método para calcular el total a pagar
        private double CalcularTotalPagar()
        {
            double total = 0;
            foreach (var producto in productosEntrada)
            {
                total += producto.SubTotal;
            }
            return total;
        }

        // Evento para registrar la entrada
        private void btnregistrar_Click(object sender, RoutedEventArgs e)
        {
            // Aquí deberías implementar la lógica para registrar la entrada en la base de datos
            // y guardar los productos asociados a la entrada

            // Después de guardar los datos, puedes cerrar la ventana de Entradas o mostrar un mensaje de éxito, etc.
            MessageBox.Show("Entrada registrada con éxito.");
            this.Close();
        }
    }

    // Clase para representar un producto en la entrada
    public class ProductoEntrada
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
    }
}