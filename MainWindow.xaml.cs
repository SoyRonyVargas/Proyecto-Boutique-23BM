using Microsoft.Windows.Themes;
using Proyecto23BMBoutique2.Auth;
using Proyecto23BMBoutique2.usuario.services;
using Proyecto23BMBoutique2.Vistas;
using Proyecto23BMBoutique2.Vistas.VistaAdministrador.Bienvenida;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto23BMBoutique2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UsuarioService usuarioService = new UsuarioService();
        private RestauranteDataContext db = new RestauranteDataContext();
        public MainWindow()
        {

            InitializeComponent();
            //Window ventana = (Window)Activator.CreateInstance(Router.routes[0].WindowType);

            //Router.openWindows.Add(ventana);
            //MainContentFrame.Navigate(new Page1());
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
            //try
            //{
            //    Entrada entrada = new Entrada
            //    {
            //        status = 1, // Asigna el valor adecuado para el status de la entrada
            //        importe = 100.00, // Asigna el importe de la entrada
            //        iva = 16.00, // Asigna el IVA de la entrada
            //        total = 116.00, // Asigna el total de la entrada
            //        ProveedorFK = 1, // Asigna el ID del proveedor asociado (cambia 1 por el ID real)
            //        UsuarioFK = 1, // Asigna el ID del usuario creador (cambia 1 por el ID real)
            //        //EntradaProductos = new Entrada_Has_Producto() { }
            //    };

            //    Entrada_Has_Producto entradaHasProducto = new Entrada_Has_Producto
            //    {
            //        Cantidad = 5,
            //        ProductoId = 1,
            //        EntradaId = 1,
            //    };

            //    entrada.EntradaProductos!.Add(entradaHasProducto);

            //    db.Entradas.Add(entrada);

            //    db.SaveChanges();

            //    var entradas = db.Entradas
            //        .Include( entrada => entrada.EntradaProductos )
            //        .ToList();

            //    Debugger.Break();
            //}
            //catch(Exception ex)
            //{
            //    Debugger.Break();
            //}

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UsuarioService service = new UsuarioService();
            string username = txtUserName.Text;
            string password = Password.Password;

            if (service.AutenticarUsuario(username, password))
            {
                Autenticacion.usuario = service.ObtenerUsuarioPorNombreUsuario(username);
                Bienvenida bienvenida = new Bienvenida();
                
                bienvenida.Show();
            }
            else { MessageBox.Show("Has ingresado información incorrecta"); }



            // Router.Navigate("/prueba");
            // this.Close();
            //GestionUsuario usuario = new GestionUsuario();
            //Close();
            //usuario.Show();
            //Bienvenida bienvenida = new Bienvenida();
            //Close();
            //bienvenida.Show();


        }
    }
}
