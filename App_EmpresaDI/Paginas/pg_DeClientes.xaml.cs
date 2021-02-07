using System;
using System.Windows;
using System.Windows.Controls;
using Capa_Logica;
using System.Data;
using LibreriasByJIM.Controles_JIM;

namespace App_EmpresaDI.Paginas
{
    /// <summary>
    /// Lógica de interacción para pg_Clientes.xaml
    /// </summary>
    public partial class pg_DeClientes : Page
    {
        Cliente cliente = new Cliente();
        public pg_DeClientes()
        {
            InitializeComponent();
            //CargamosDatos();             
        }

        private void CargamosDatos()
        {
            DataTable dt = cliente.Damelistado();

            if (dt != null)
                dgv_Clientes.ItemsSource = dt.DefaultView;          
        }

        private void TrabajoBotones(object sender, RoutedEventArgs e)
        {
            if (ComprobamosDatos())
            {
                switch (((Button)sender).Name)
                {
                    case "btnAdd":
                        new MensajeBox("CLIENTE INTRODUCIDO CON EXITO");
                        break;
                    case "btnupdate":
                        new MensajeBox("CLIENTE ACTUALIZADO CON EXITO");
                        break;
                    case "btnDel":
                        new MensajeBox("CLIENTE ELIMINADO CON EXITO");
                        break;
                }
            }
        }


        #region TRABAJAMOS LA BBDD

        private Boolean ComprobamosDatos()
        {
            if (txtNombre.Frase == "" || txtNombre.Frase == txtNombre.Hint)
            {
                new MensajeBox("EL NOMBRE DEL CLIENTE NO PUEDE ESTAR VACIO");
                return false;
            }
            else if (txtTelefono.Frase == "" || txtTelefono.Frase == txtTelefono.Hint)
            {
                new MensajeBox("EL TELEFONO DEL CLIENTE NO PUEDE ESTAR VACIO");
                return false;
            }
            else if (txtDireccion.Frase == "" || txtDireccion.Frase == txtDireccion.Hint)
            {
                new MensajeBox("LA DIRECCION DEL CLIENTE NO PUEDE ESTAR VACIO");
                return false;
            }
            else if (txtCiudad.Frase == "" || txtCiudad.Frase == txtCiudad.Hint)
            {
                new MensajeBox("LA CIUDAD DEL CLIENTE NO PUEDE ESTAR VACIO");
                return false;
            }
            return true;
        }

        private void creamosCliente()
        {
            cliente = new Cliente();
            cliente.Nombre = txtNombre.Content.ToString();
            cliente.Telefono = txtTelefono.Content.ToString(); ;
            cliente.Direccion = txtDireccion.Content.ToString();
        }


        #endregion

        #region TRABAJOS DE DISEÑO

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
        #endregion

    }
}
