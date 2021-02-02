using System;
using System.Windows;
using System.Windows.Controls;
using ControlesByJIM;
using Capa_Logica;
using System.Data;

namespace App_EmpresaDI.Paginas
{
    /// <summary>
    /// Lógica de interacción para pg_Clientes.xaml
    /// </summary>
    public partial class pg_Clientes : Page
    {
        Cliente cliente = new Cliente();
        public pg_Clientes()
        {
            InitializeComponent();
            
             dgv_Clientes.ItemsSource = cliente.Damelistado().DefaultView;
        }

        private void TrabajoBotones(object sender, RoutedEventArgs e)
        {
            ComprobamosDatos();
            switch (((Button)sender).Name)
            {
                case "btnAdd":                 
                    new wid_MessageBox("CLIENTE INTRODUCIDO CON EXITO");
                    break;
                case "btnupdate":
                    new wid_MessageBox("CLIENTE ACTUALIZADO CON EXITO");
                    break;
                case "btnDel":
                    new wid_MessageBox("CLIENTE ELIMINADO CON EXITO");
                    break;
            }
        }

        private void ComprobamosDatos()
        {
            if (txtNombre.Frase == "" || txtNombre.Frase == txtNombre.Hint)
            {
                new wid_MessageBox("EL NOMBRE DEL CLIENTE NO PUEDE ESTAR VACIO");
            }
            else if (txtTelefono.Frase == "" || txtTelefono.Frase == txtTelefono.Hint)
            {
                new wid_MessageBox("EL TELEFONO DEL CLIENTE NO PUEDE ESTAR VACIO");
            }
            else if (txtDireccion.Frase == "" || txtDireccion.Frase == txtDireccion.Hint)
            {
                new wid_MessageBox("LA DIRECCION DEL CLIENTE NO PUEDE ESTAR VACIO");
            }
            else if (txtCiudad.Frase == "" || txtCiudad.Frase == txtCiudad.Hint)
            {
                new wid_MessageBox("LA CIUDAD DEL CLIENTE NO PUEDE ESTAR VACIO");
            }
        }




        private void AjusteFuentes(object sender, SizeChangedEventArgs e)
        {
            Double factorFuente = 0.05;
            txtNombre.FontSize = this.ActualHeight * factorFuente;
            txtDireccion.FontSize = this.ActualHeight * factorFuente;
            txtCiudad.FontSize = this.ActualHeight * factorFuente;
            txtTelefono.FontSize = this.ActualHeight * factorFuente;
            txtObservaciones.FontSize = this.ActualHeight * 0.04;

            foreach (Button btn in grid_Botones.Children)
            {
                ((Button)btn).FontSize = this.ActualHeight * 0.03;
            }
        }

    }
}
