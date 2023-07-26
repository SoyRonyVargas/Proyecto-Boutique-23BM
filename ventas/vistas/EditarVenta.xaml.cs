using Proyecto23BMBoutique2.ventas.entities;
using Proyecto23BMBoutique2.ventas.services;
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

namespace Proyecto23BMBoutique2.ventas.vistas
{
    /// <summary>
    /// Lógica de interacción para EditarVenta.xaml
    /// </summary>
    public partial class EditarVenta : UserControl
    {
        private readonly VentaService ventaService = new VentaService();
        private int? idVenta = null;

        public EditarVenta(int id_venta)
        {
            InitializeComponent();
            this.idVenta = id_venta;
            this.handleLoadVentas(id_venta);
        }

        private void handleLoadVentas(int id)
        {
            Venta venta = this.ventaService.GetVentaById(id)!;
            gridEditProductos.ItemsSource = venta.Productos;
            labelImporte.Content = venta.importe.ToString("C2");
            labelIVA.Content = venta.iva.ToString("C2");
            labelTotal.Content = venta.total.ToString("C2");
            labelId.Content = labelId.Content + venta.id.ToString();
        }
    }
}
