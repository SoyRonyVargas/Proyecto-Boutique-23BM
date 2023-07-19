using Proyecto23BMBoutique2.entradas.entities;
using Proyecto23BMBoutique2.ventas.entities;
using Proyecto23BMBoutique2.ventas.services;
using ProyectoBoutique23BM.Clases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Proyecto23BMBoutique2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RestauranteDataContext db = new RestauranteDataContext();

        public MainWindow()
        {
            InitializeComponent();
            //VentaService service = new VentaService();
            //Venta venta = new Venta();
            //venta.total = 116;
            //venta.iva = 16;
            //venta.importe = 100;
            //venta.status = 0;
            //venta.VendedorFK = 1;

            //VentaProducto producto1 = new VentaProducto();
            //producto1.total = 116;
            //producto1.iva = 16;
            //producto1.importe = 100;
            //producto1.status = 0;
            //producto1.ProductoFK = 1;
            //producto1.cantidad = 1;
            //venta.Productos.Add(producto1);
            //Venta venta_nueva = service.AddVenta(venta);
            //Venta? ventaBusc = service.GetVentaById(1);
            try
            {
                Entrada entrada = new Entrada
                {
                    status = 1, // Asigna el valor adecuado para el status de la entrada
                    importe = 100.00, // Asigna el importe de la entrada
                    iva = 20.00, // Asigna el IVA de la entrada
                    total = 120.00, // Asigna el total de la entrada
                    ProveedorFK = 1, // Asigna el ID del proveedor asociado (cambia 1 por el ID real)
                    UsuarioFK = 1, // Asigna el ID del usuario creador (cambia 1 por el ID real)
                    //EntradaProductos = new Entrada_Has_Producto() { }
                };

                db.Entradas.Add(entrada);

                db.SaveChanges();

                //var entradaHasProducto = new Entrada_Has_Producto
                //{
                //    Cantidad = 5,
                //    ProductoId = 1,
                //    EntradaId = entrada.id,
                //};

                // Relacionar la entrada_has_producto con la entrada

                //db.Entradas.Add(entrada);

                //db.SaveChanges();
                
                //entrada.EntradaProductos.Add(entradaHasProducto);

                //db.SaveChanges();

                Debugger.Break();
            }
            catch(Exception ex)
            {
                Debugger.Break();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
