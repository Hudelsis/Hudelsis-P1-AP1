using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hudelsis_P1_AP1.Entidades;
using Hudelsis_P1_AP1.BLL;
using Hudelsis_P1_AP1.DAL;
using Microsoft.EntityFrameworkCore;

namespace Hudelsis_P1_AP1.UI.Consultas
{
    public partial class cCiudad : Window
    {
        public cCiudad()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ciudad>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: 
                        listado = CiudadBLL.GetList(e => e.CiudadId == int.Parse(CriterioTextBox.Text));
                        break;

                    case 1:                       
                        listado = CiudadBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }
            else
            {
                listado = CiudadBLL.GetList(c => true);
            }

            //DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }


    }
}