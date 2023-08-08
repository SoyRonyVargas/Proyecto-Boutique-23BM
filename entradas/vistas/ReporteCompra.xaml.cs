using Proyecto23BMBoutique2.Auth;
using Proyecto23BMBoutique2.entrada.services;
using Proyecto23BMBoutique2.entradas.entities;
using Proyecto23BMBoutique2.producto.services;
using Proyecto23BMBoutique2.proveedor.services;
using ProyectoBoutique23BM.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto23BMBoutique2.entradas.vistas
{
    public partial class ReporteCompra : UserControl
    {
        private List<Entrada_Has_Producto> productosSeleccionados = new List<Entrada_Has_Producto>();
        private readonly ProductoService productoService = new ProductoService();
        private readonly EntradaService entradaService = new EntradaService();
        private double importe = 0;
        private double iva = 0;
        private double total = 0;

        public ReporteCompra()
        {
            InitializeComponent();
            UpdateSelectProveedor();
            UpdateSelectProducto();

        }

        private void CantidadTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            // Obtenemos la referencia al TextBox que ha sido cargado
            TextBox cantidadTextBox = sender as TextBox;
            if (cantidadTextBox != null)
            {
                // Ahora suscribimos al evento TextChanged del TextBox
                cantidadTextBox.TextChanged += CantidadTextBox_TextChanged;
            }
        }

        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {

                // Obtenemos el valor actual del TextBox

                string valorActual = textBox.Text;

                if (int.TryParse(valorActual, out int nuevaCantidad))
                {
                    
                    Entrada_Has_Producto? contextEntradaProducto = textBox.DataContext as Entrada_Has_Producto;

                    contextEntradaProducto!.cantidad = nuevaCantidad;

                    RenderGrid();

                    textBox.Focus();

                }

            }

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para manejar el evento de clic del botón aquí
            // Por ejemplo, puedes obtener el objeto de la fila del DataGrid asociado al botón
            // y eliminar el registro correspondiente de tu colección de datos.
            // Puedes acceder al DataContext del botón para obtener el objeto asociado a la fila:
            var boton = sender as Button;

            if (boton == null) return;

            Entrada_Has_Producto? botonContext = boton.DataContext as Entrada_Has_Producto;

            this.productosSeleccionados.Remove(botonContext!);

            RenderGrid();

        }

        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void UpdateSelectProveedor()
        {
            ProveedorService proveedorServices = new ProveedorService();
            selectproveedor.ItemsSource = proveedorServices.ObtenerTodosLosProveedores();
            selectproveedor.DisplayMemberPath = "nombre";
            selectproveedor.SelectedValuePath = "id";
        }
        public void UpdateSelectProducto()
        {
            ProductoService productoServices = new ProductoService();
            selectproveedor.ItemsSource = productoServices.ObtenerTodosLosProductos();
            selectproveedor.DisplayMemberPath = "nombre";
            selectproveedor.SelectedValuePath = "id";
        }

        private void btnbuscarproducto_Copy_Click(object sender, RoutedEventArgs e)
        {
            string nombreProducto = input_producto.Text;

            List<Producto> productosPorNombre = this.productoService.ObtenerProductosPorNombre(nombreProducto);

            comboProductos.ItemsSource = productosPorNombre;
            comboProductos.DisplayMemberPath = "descripcion";
            comboProductos.SelectedIndex = 0;
        }

        private void RenderGrid()
        {
            List<Entrada_Has_Producto> productos = relacionarProductos();
            gridProductosEntrada.ItemsSource = null;
            gridProductosEntrada.ItemsSource = productos;
        }

        private List<Entrada_Has_Producto> relacionarProductos()
        {
            List<Entrada_Has_Producto> relaciones = new List<Entrada_Has_Producto>();
            this.importe = 0;
            this.total = 0;
            this.iva = 0;
            foreach (Entrada_Has_Producto _producto in this.productosSeleccionados)
            {

                Producto? producto = productoService.ObtenerProductoPorId(_producto.ProductoId);

                _producto.Producto = producto!;

                _producto.importe = _producto.cantidad * _producto.Producto.precio;

                _producto.iva = _producto.importe * 0.16;

                _producto.total = _producto.importe + _producto.iva;

                this.importe += _producto.importe;
                this.iva += _producto.iva;
                this.total += _producto.total;

                relaciones.Add(_producto);

            }

            labelImporte.Content = this.importe.ToString("C2");
            labelIVA.Content = this.iva.ToString("C2");
            labelTotal.Content = this.total.ToString("C2");

            return relaciones;

        }
        private bool hasProductosEnCero()
        {
            return productosSeleccionados.Any(p => p.cantidad == 0);
        }

        private void handleGuardarEntrada(object sender, System.Windows.RoutedEventArgs e)
        {
            
            bool productosEnCero = hasProductosEnCero();

            if (productosEnCero )
            {

                MessageBox.Show("Algunos productos en la entrada estan en 0");

                return;

            } 

            if (productosSeleccionados.Count == 0)
            {

                MessageBox.Show("La entrada no contiene productos");

                return;

            }
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro que deseas finalizar la entrada?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resultado != MessageBoxResult.Yes) return;

            Entrada entrada = new Entrada()
            {
                importe = this.importe,
                iva = this.iva,
                total = this.total,
                status = 0,
                ProveedorFK = 1,
                UsuarioFK = Autenticacion.usuario!.id,
            };

            List<Entrada_Has_Producto>? productos = gridProductosEntrada.ItemsSource as List<Entrada_Has_Producto>;

            bool response = entradaService.AgregarEntrada(entrada , productos);

            if (response)
            {
                MessageBox.Show("Entrada creada exitosamente");

                if (App.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.handleRouter("listarEntradas");
                }

            }
            else
            {
                MessageBox.Show("Error al crear la entrada");
            }

        }
   
        private void btnbuscarproducto_Click(object sender, RoutedEventArgs e)
        {
            Entrada_Has_Producto entrada = new Entrada_Has_Producto();

            Producto? productoSeleccionado = comboProductos.SelectedItem as Producto;

            if (this.productosSeleccionados.Where(p => p.ProductoId == productoSeleccionado!.id).FirstOrDefault() != null)
            {

                MessageBox.Show("Producto ya agregado");

                return;

            }

            entrada.ProductoId = productoSeleccionado!.id;

            productosSeleccionados.Add(entrada);

            RenderGrid();

        }
    } 
}
