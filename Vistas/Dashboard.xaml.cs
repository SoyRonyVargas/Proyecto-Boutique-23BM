using System;
using System.Windows.Controls;
using Proyecto23BMBoutique2.ventas.services;
using ProyectoBoutique23BM.Clases;
using LiveCharts;
using LiveCharts.Wpf;
using Proyecto23BMBoutique2.ventas.entities;
using System.Collections.Generic;
using LiveCharts.Defaults;

namespace Proyecto23BMBoutique2.Vistas
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        private readonly VentaService ventaService = new VentaService();
        private readonly RestauranteDataContext db = new RestauranteDataContext();

        public Dashboard()
        {
            
            InitializeComponent();

            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;

            List<MejorProducto> mejoresProductos = this.ventaService.GetMejoresProductos();
            List<MejorVendedor> mejoresVendedores = handleLoadMejoresVendedores();
            List<Venta> mejoresVentasPorUsuario = this.ventaService.GetVentasPorUsuario();

            ColumnSeries vendedores = new ColumnSeries
            {
                Values = new ChartValues<double> {}
            };

            Labels = new string[mejoresVendedores.Count];

            int i = 0;
            
            foreach( MejorVendedor _vendedor in mejoresVendedores)
            {
                vendedores.Values.Add(_vendedor.total);
                Labels[i] = _vendedor.Vendedor;
                i++;
            }
            SeriesProducto = new SeriesCollection
            {

            };
            foreach (MejorProducto _producto in mejoresProductos)
            {
                PieSeries pie = new PieSeries
                {
                    Title = _producto.nombre,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(_producto.cantidad) },
                    DataLabels = true
                };
                
                SeriesProducto.Add(pie);

            }

            SeriesCollection = new SeriesCollection
            {
                vendedores
            };

            // VENTAS POR USUARIOS

            YFormatter = value => value.ToString("C");
            
            LabelsCompras = new string[mejoresVentasPorUsuario.Count];
            
            SeriesGastos = new SeriesCollection
            {
                
            };
            
            LineSeries linea = new LineSeries
            {
                Title = "Total: ",
                //Values = 
            };
            
            ChartValues<double> totales = new ChartValues<double> {};

            int j = 0;
            foreach (Venta Venta in mejoresVentasPorUsuario)
            {
                totales.Add(Venta.total);
                LabelsCompras[j] = "Venta " + Venta.id.ToString();
                j++;
            }

            linea.Values = totales;

            SeriesGastos.Add(linea);

            Formatter = value => value.ToString("N");

            DataContext = this;

        }


        public List<MejorVendedor> handleLoadMejoresVendedores()
        {
            return this.ventaService.GetMejoresVendedores();
        }

        public Func<ChartPoint, string> PointLabel { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection SeriesProducto { get; set; }
        public SeriesCollection SeriesGastos { get; set; }
        public string[] Labels { get; set; }
        public string[] LabelsCompras { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

    }
}
