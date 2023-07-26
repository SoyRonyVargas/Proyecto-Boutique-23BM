using Proyecto23BMBoutique2.Auth;
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
    /// Lógica de interacción para vista_editar_proveedor.xaml
    /// </summary>
    public partial class vista_editar_proveedor : UserControl
    {
        private readonly ProveedorService proveedorService = new ProveedorService();
        private int? proveedor_id = null;
        public vista_editar_proveedor(int id)
        {
            this.proveedor_id = id;
            InitializeComponent();
            mounted(id);
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreedit.Text) && !string.IsNullOrEmpty(Txtcontactoedit.Text) && !string.IsNullOrEmpty(TxtEmpresaedit.Text) && !string.IsNullOrEmpty(TxtDireccionedit.Text) && !string.IsNullOrEmpty(Txttelefonoedit.Text) && !string.IsNullOrEmpty(TxtCorreoedit.Text))
            {

                string nombre = txtNombreedit.Text;
                string correo = TxtCorreoedit.Text;
                string empresa = TxtEmpresaedit.Text;
                string telefono = Txttelefonoedit.Text;
                string direccion = TxtDireccionedit.Text;
                string contacto = Txtcontactoedit.Text;

                Proveedor proveedor = new Proveedor();

                proveedor.id = this.proveedor_id ?? 0;
                proveedor.nombre = nombre;
                proveedor.correo_electronico = correo;
                proveedor.empresa = empresa;
                proveedor.telefono = telefono;
                proveedor.direccion = direccion;
                proveedor.contacto = contacto;

                this.proveedorService.ActualizarProveedor(proveedor);

                MessageBox.Show("SE HA EDITADO CORRECTAMENTE EL PROVEEDOR");

                if (App.Current.MainWindow is MainWindow mainWindow)
                {
                    // Llama a la función handleClick en MainWindow
                    mainWindow.handleRouter("ListarProveedor");
                }

            }
            else
            {
                MessageBox.Show("No has ingresado todos los datos");
            }
           
        }

        public void mounted(int id_proveedor)
        {

            Proveedor? proveedor = this.proveedorService.ObtenerProveedorPorId(id_proveedor);

            if (proveedor == null) return;

            txtNombreedit.Text = proveedor.nombre;
            Txtcontactoedit.Text = proveedor.contacto;
            TxtCorreoedit.Text = proveedor.correo_electronico;
            TxtDireccionedit.Text = proveedor.direccion;
            TxtEmpresaedit.Text = proveedor.empresa;
            Txttelefonoedit.Text = proveedor.telefono;
            
        }
       
    }
}
