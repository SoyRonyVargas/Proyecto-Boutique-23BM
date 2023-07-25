using Proyecto23BMBoutique2.producto.services;
using System.Windows.Controls;

namespace Proyecto23BMBoutique2.ventas.vistas
{
    /// <summary>
    /// Lógica de interacción para CrearVenta.xaml
    /// </summary>
    public partial class CrearVenta : UserControl
    {

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
            
            int codigo = int.Parse(input_codigo.Text);

            //if (codigo) return;

            this.productoService.ObtenerProductoPorId(codigo);

        }
    }
}
