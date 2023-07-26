using Proyecto23BMBoutique2.Auth;
using Proyecto23BMBoutique2.proveedor.services;
using Proyecto23BMBoutique2.proveedores.entities;
using Proyecto23BMBoutique2.usuario.services;
using Proyecto23BMBoutique2.Vistas.VistaAdministrador.Bienvenida;
using ProyectoBoutique23BM.Clases;
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

namespace Proyecto23BMBoutique2.proveedores.vistas
{
    /// <summary>
    /// Lógica de interacción para ListarProveedores.xaml
    /// </summary>
    public partial class ListarProveedores : UserControl
    {
        public ListarProveedores()
        {
            InitializeComponent();
            UpdateProveedorTable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                // Llama a la función handleClick en MainWindow
                mainWindow.handleRouter("crearproveedor");
            }

        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Proveedor proveedor = (sender as FrameworkElement).DataContext as Proveedor;
            
            int id = proveedor.id;

            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.handleRouter("editarproveedor", id);
            }
            

        }

        private void MenuP(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Bienvenida1 bienvenida = new Bienvenida1();
            //Close();
            bienvenida.Show();
        }
        private void btnDeleteProveedor_Click(object sender, RoutedEventArgs e)
        {
            var confirmarDeleteProveedor = new MessageBoxTrueFalse("¿Deseas emliminar el Proveedor?");
            var result = confirmarDeleteProveedor.ShowDialog();

            if (result.HasValue && result.Value)
            {
               ProveedorService services = new ProveedorService();
                Proveedor proveedor = new Proveedor();
                proveedor = (sender as FrameworkElement).DataContext as Proveedor;
                services.EliminarProveedor(proveedor.id);
                UpdateProveedorTable();
            }
            else { }
       
        }
        public void UpdateProveedorTable()
        {
            ProveedorService proveedorServices = new ProveedorService();
            UserTable.ItemsSource = proveedorServices.ObtenerTodosLosProveedores();
        }

      
    }
}
