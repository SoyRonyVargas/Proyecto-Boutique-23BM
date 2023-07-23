using System.Windows.Controls;

namespace Proyecto23BMBoutique2.ventas.vistas
{
    /// <summary>
    /// Lógica de interacción para CrearVenta.xaml
    /// </summary>
    public partial class CrearVenta : UserControl
    {
        public CrearVenta()
        {
            InitializeComponent();
        }

        public void handle()
        {
            var x = new MainWindow();
            x.handleRouter("");
        }
    }
}
