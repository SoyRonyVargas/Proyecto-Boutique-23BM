﻿using Proyecto23BMBoutique2.Vistas.VistaAdministrador.HacerPedido;
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

namespace Proyecto23BMBoutique2.Vistas.VistaAdministrador.Bienvenida
{
    /// <summary>
    /// Lógica de interacción para Bienvenida.xaml
    /// </summary>
    public partial class Bienvenida1 : Window
    {
        public Bienvenida1()
        {
            InitializeComponent();
        }
        private void GestionUser(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GestionUsuario ges = new GestionUsuario();
            Close();
            ges.Show();
        }
        private void PuntoVenta(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }
        private void LogOut(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();

        }
        private void Inventario(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }
        private void HacerPedido(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HacerPedidoss hacer = new HacerPedidoss();
            Close();
            hacer.Show();
        }
    }
}