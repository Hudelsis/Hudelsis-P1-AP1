﻿using System;
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
using Hudelsis_P1_AP1.UI.Registro;
using Hudelsis_P1_AP1.UI.Consultas;

namespace Hudelsis_P1_AP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
         private void rCiudadMenu_Click(object sender, RoutedEventArgs e)
        {
            rCiudad ventana = new rCiudad();
            ventana.Show();

            
        }
        private void cCiudadMenu_Click(object sender, RoutedEventArgs e)
        {
            cCiudad ventana = new cCiudad();
            ventana.Show();

            
            
        }
        private void AyudaMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
