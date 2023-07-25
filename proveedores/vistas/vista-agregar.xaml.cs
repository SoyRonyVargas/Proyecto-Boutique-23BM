using Proyecto23BMBoutique2.proveedor.services;
using Proyecto23BMBoutique2.proveedores.entities;
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
    /// Lógica de interacción para vista_agregar.xaml
    /// </summary>
    public partial class vista_agregar : UserControl
    {
        private ProveedorService proveedorService = new ProveedorService();
        public vista_agregar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string correo = TxtCorreo.Text;
            string empresa = TxtEmpresa.Text;
            string telefono = Txttelefono.Text;
            string direccion = TxtDireccion.Text;
            string contacto = Txtcontacto.Text;

            Proveedor proveedor = new Proveedor();
            proveedor.nombre = nombre;
            proveedor.correo_electronico = correo;
            proveedor.empresa= empresa;
            proveedor.telefono = telefono;
            proveedor.direccion = direccion;
            proveedor.contacto = contacto;

            this.proveedorService.AgregarProveedor(proveedor);

            MessageBox.Show("SE HA GUARDADO CORRECTAMENTE EL PROVEEDOR");
            
            if (App.Current.MainWindow is MainWindow mainWindow)
            {
                // Llama a la función handleClick en MainWindow
                mainWindow.handleRouter("listasVentas");
            }


        }
    }
}
