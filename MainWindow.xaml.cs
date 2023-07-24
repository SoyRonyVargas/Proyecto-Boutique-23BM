﻿using Proyecto23BMBoutique2.Auth;
using Proyecto23BMBoutique2.usuario.services;
using Proyecto23BMBoutique2.usuario.vistas;
using Proyecto23BMBoutique2.ventas.vistas;
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

            //new Ventas().Show();
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
           Bienvenida1 bienvenida = new Bienvenida1();
            Close();
            bienvenida.Show();  
        }

        private void TBShow(object sender, RoutedEventArgs e)
        {
            // Router.Navigate("/prueba");
            // this.Close();
            //GestionUsuario usuario = new GestionUsuario();
            //Close();
            //usuario.Show();
            //Bienvenida bienvenida = new Bienvenida();
            Close();
            //bienvenida.Show();
        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new VentasC();
        }

        public void handleRouter( string ruta )
        {
            if( ruta == "crearVenta" )
            {
                DataContext = new CrearVenta();
            }
            
            if (ruta == "listarUsuarios") DataContext = new ListarUsuarios();
            
            if (ruta == "crearUsuario") DataContext = new CrearUsuario();
            
        }

        private void handleListarUsuarios(object sender, RoutedEventArgs e)
        {
            this.handleRouter("listarUsuarios");
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new BienvenidaControl();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string usuario = input_usuario.Text;
            string password = input_password.Text;

            if( usuario.Trim().Length == 0 )
            {

                MessageBox.Show("Ingresa el campo usuario");

                return;

            }
            if (password.Trim().Length == 0)
            {

                MessageBox.Show("Ingresa el campo contraseña");

                return;

            }

            bool response = usuarioService.AutenticarUsuario(usuario, password);

            if( !response )
            {
                MessageBox.Show("Usuario no valido");
                return;
            }

            Autenticacion.usuario = this.usuarioService.ObtenerUsuarioPorNombreUsuario(usuario);

            gridPrincipal.Visibility = Visibility.Visible;
            gridLogin.Visibility = Visibility.Collapsed;


        }
    }
}

