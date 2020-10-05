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

namespace Hudelsis_P1_AP1.UI.Registro
{
    /// <summary>
    /// Lógica de interacción para rClientes.xaml
    /// </summary>
    public partial class rCiudad : Window
    {
        private bool editando = false;

        private Ciudad ciudad;
        public rCiudad()
        { 
            InitializeComponent();  
            Limpiar();
        }

        private void Limpiar()
        {
            this.ciudad = new Ciudad();
            IDTextBox.IsEnabled = true;
            IDTextBox.Text = "";
            this.DataContext = ciudad;
        }

        private bool Validar()
        {
            bool esValido = true; 

            if(editando){
                if(IDTextBox.Text.Length == 0){
                    esValido = false;
                MessageBox.Show("Transaccion Fallida, " );
                }
            }

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo");
            }

            return esValido; 
        }

        private void mostrarDatos(){ 
                IDTextBox.Text = ciudad.CiudadId.ToString();
                NombresTextBox.Text = ciudad.Nombres;
                
        } 

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        { 
             if (IDTextBox.Text.Length ==0){
                return;
            }

        ciudad = CiudadBLL.Buscar(int.Parse(IDTextBox.Text));

            if (ciudad!= null)
                mostrarDatos();
            else
            ciudad = new Ciudad();


         this.DataContext = this.ciudad;
         editando = true; 
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar(); 
            editando = false;
        } 

        private void GuardarCiudadButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar(); 
            editando = false;
        } 

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            int id = 0;

            if (!Validar())
                return;

            if(IDTextBox.Text.Length > 0){
                id = int.Parse(IDTextBox.Text);
            }

            ciudad.CiudadId= id ;
            ciudad.Nombres = NombresTextBox.Text;
             
            
            if(!editando){
                paso = CiudadBLL.Guardar(ciudad);
               
            }else{
                paso = CiudadBLL.Modificar(ciudad);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transacciones exitosa!", "Existo");
            }
            else{
                MessageBox.Show("Transacciones Fallida", "Fallo");
            } 
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        { 
            if (CiudadBLL.Eliminar(int.Parse(IDTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Existo");
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo"); 
        }
    }
}