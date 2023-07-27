using Proyecto23BMBoutique2.Clases;
using Proyecto23BMBoutique2.entrada.services;
using Proyecto23BMBoutique2.entradas.entities;
using Proyecto23BMBoutique2.producto.services;
using Proyecto23BMBoutique2.proveedor.services;
using Proyecto23BMBoutique2.rol.services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Proyecto23BMBoutique2.entradas.vistas
{
    public partial class ReporteCompra : UserControl
    {
        Entrada_Has_Producto entradaHasProducto = new Entrada_Has_Producto();
        EntradaService service = new EntradaService();

        public ReporteCompra()
        {
            InitializeComponent();
            UpdateSelectProveedor();
            UpdateSelectProducto();

        }
        private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    if (selectProducto.SelectedItem != null && selectProducto.SelectedItem != null && !string.IsNullOrEmpty(txtCantidad.Text))
                    {
                        entradaHasProducto.Cantidad = int.Parse(txtCantidad.Text);
                        entradaHasProducto.ProductoId = int.Parse(selectProducto.SelectedValue.ToString());

                        service.AgregarEntrada(entradaHasProducto);
                        MessageBox.Show("Producto añadido correctamente");
                        if (App.Current.MainWindow is MainWindow mainWindow)
                        {
                            mainWindow.handleRouter("listarProductos");
                        }
                    }
                }
                catch (Exception ex) { Errors.handle(ex);

                }
            
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
    } 
}
