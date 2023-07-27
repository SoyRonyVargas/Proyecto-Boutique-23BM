using Proyecto23BMBoutique2.entrada.services;
using Proyecto23BMBoutique2.entradas.entities;
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

namespace Proyecto23BMBoutique2.entradas.vistas
{
    /// <summary>
    /// Lógica de interacción para EditarEntrada.xaml
    /// </summary>
    public partial class EditarEntrada : UserControl
    {
        private readonly EntradaService entradaService = new EntradaService();
        public EditarEntrada(int id)
        {
            InitializeComponent();
            mounted(id);
        }
        public void mounted(int id)
        {
            Entrada entrada = this.entradaService.ObtenerEntradaPorId(id)!;
            labelImporte.Content = entrada.importe.ToString("C2");
            labelIVA.Content = entrada.iva.ToString("C2");
            labelTotal.Content = entrada.total.ToString("C2");
            gridProductosEntrada.ItemsSource = entrada.EntradaProductos;
        }
    }
}
