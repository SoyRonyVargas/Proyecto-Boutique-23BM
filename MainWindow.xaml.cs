using Proyecto23BMBoutique2.ventas.entities;
using Proyecto23BMBoutique2.ventas.services;
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
            //List<VentaProducto> produtos = new List<VentaProducto>();
            //produtos.Add(producto1);
            //Venta venta_nueva = service.AddVenta(venta);
            //bool response = service.AddVentaProductos(venta_nueva.id, produtos);
            //Venta? ventaBusc = service.GetVentaById(4);
            //Debugger.Break();
        }
    }
}
