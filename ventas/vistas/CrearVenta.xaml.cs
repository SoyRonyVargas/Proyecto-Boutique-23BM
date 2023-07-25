﻿using Proyecto23BMBoutique2.producto.services;
using Proyecto23BMBoutique2.ventas.entities;
using ProyectoBoutique23BM.Clases;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto23BMBoutique2.ventas.vistas
{
    /// <summary>
    /// Lógica de interacción para CrearVenta.xaml
    /// </summary>
    public partial class CrearVenta : UserControl
    {

        private List<VentaProducto> productosSeleccionados = new List<VentaProducto>();
        private readonly ProductoService productoService = new ProductoService();
        public CrearVenta()
        {
            InitializeComponent();
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

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para manejar el evento de clic del botón aquí
            // Por ejemplo, puedes obtener el objeto de la fila del DataGrid asociado al botón
            // y eliminar el registro correspondiente de tu colección de datos.
            // Puedes acceder al DataContext del botón para obtener el objeto asociado a la fila:
            var boton = sender as Button;
            
            if (boton == null) return;

            VentaProducto? botonContext = boton.DataContext as VentaProducto;

            this.productosSeleccionados.Remove(botonContext);

            RenderGrid();

        }

        // Controlador de eventos para el evento TextChanged del TextBox
        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                
                // Obtenemos el valor actual del TextBox
                
                string valorActual = textBox.Text;

                //Debugger.Break();

                if (int.TryParse(valorActual, out int nuevaCantidad))
                {
                    VentaProducto contextProducto = textBox.DataContext as VentaProducto;

                    contextProducto.cantidad = nuevaCantidad;

                    RenderGrid();

                    textBox.Focus();

                }

            }

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
            
            //int codigo = int.Parse(input_codigo.Text);

            //if (codigo) return;

            //this.productoService.ObtenerProductoPorId(codigo);

        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            string nombreProducto = input_nombre_producto.Text;

            List<Producto> productosPorNombre = this.productoService.ObtenerProductosPorNombre(nombreProducto);

            comboProductos.ItemsSource = productosPorNombre;
            comboProductos.DisplayMemberPath = "descripcion";
            comboProductos.SelectedIndex = 0;

        }

        private void CalcularImportes()
        {

        }

        private List<VentaProducto> relacionarProductos()
        {
            List<VentaProducto> relaciones = new List<VentaProducto>();

            foreach( VentaProducto _producto in this.productosSeleccionados )
            {
                Producto producto = productoService.ObtenerProductoPorId(_producto.ProductoFK);
                
                _producto.Producto = producto;
                
                _producto.importe = _producto.cantidad * _producto.Producto.precio;

                _producto.iva = _producto.importe * 0.16;

                _producto.total = _producto.importe + _producto.iva;

                relaciones.Add(_producto);

            }

            return relaciones;
        }

        private void RenderGrid()
        {
            List<VentaProducto> productos = relacionarProductos();
            //Debugger.Break();
            gridProductosSeleccionados.ItemsSource = null;
            gridProductosSeleccionados.ItemsSource = productos;
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {

            VentaProducto productoNuevo = new VentaProducto();

            Producto? productoSeleccionado = comboProductos.SelectedItem as Producto;

            if (this.productosSeleccionados.Where(p => p.ProductoFK == productoSeleccionado!.id).FirstOrDefault() != null)
            {
                
                MessageBox.Show("Producto ya agregado");
                
                return;

            }

            productoNuevo.ProductoFK = productoSeleccionado!.id;

            productosSeleccionados.Add(productoNuevo);

            RenderGrid();

            //Debugger.Break();

        }
    }
}
