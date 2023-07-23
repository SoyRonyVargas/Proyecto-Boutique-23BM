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
using System.Windows.Shapes;

namespace Proyecto23BMBoutique2
{
    /// <summary>
    /// Lógica de interacción para CustomMessageBoxWindow.xaml
    /// </summary>
    public partial class MessageBoxTrueFalse : Window
    {
        public string Message { get; set; }
        public bool Result { get; private set; }

        public MessageBoxTrueFalse(string message)
        {
            InitializeComponent();
            Message = message;
            DataContext = this;
        }

        private void OnAcceptClicked(object sender, RoutedEventArgs e)
        {
            Result = true;
            DialogResult = true;
        }

        private void OnCancelClicked(object sender, RoutedEventArgs e)
        {
            Result = false;
            DialogResult = false;
        }
    }
}
