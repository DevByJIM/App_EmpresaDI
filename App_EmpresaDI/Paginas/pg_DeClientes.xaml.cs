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
            CargamosDatos();             
        }

        private void CargamosDatos()
        {
            DataTable dt = Tb_Clientes.listadoClientes();

            if (dt != null)
                dgv_Clientes.ItemsSource = dt.DefaultView;          
        }

        private void TrabajoBotones(object sender, RoutedEventArgs e)
        {
            if (ComprobamosDatos())
            {
                switch (((Button)sender).Name)
                {
                    case "btn_Add":
                        creamosCliente();
                        if (Tb_Clientes.addCliente(cliente)) 
                            new MensajeBox("CLIENTE INTRODUCIDO CON EXITO");
                        break;
                    case "btn_Update":
                        creamosCliente();
                        if (Tb_Clientes.updateCliente(cliente))
                            new MensajeBox("CLIENTE ACTUALIZADO CON EXITO");
                        break;
                    case "btn_Del":
                        creamosCliente();
                        if (Tb_Clientes.delCliente(cliente))
                            new MensajeBox("CLIENTE ELIMINADO CON EXITO");
                        break;
                }
                CargamosDatos();
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
            cliente.Nombre = txtNombre.Frase;
            cliente.Telefono = txtTelefono.Frase;
            cliente.Direccion = txtDireccion.Frase;
            cliente.Ciudad = txtCiudad.Frase;
            cliente.Observaciones = txtObservaciones.Frase;
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

        private void CargaInformacion(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataRowView miRow = (DataRowView)dgv_Clientes.SelectedItem;
            txtNombre.txtEntrada.Text = (miRow["CLI_NOMBRE"].ToString());
            txtTelefono.txtEntrada.Text = (miRow["CLI_TELEFONO"].ToString());
            txtDireccion.txtEntrada.Text = (miRow["CLI_DIRECCION"].ToString());
            txtCiudad.txtEntrada.Text = (miRow["CLI_CIUDAD"].ToString());
            txtObservaciones.txtEntrada.Text = (miRow["CLI_OBSERV"].ToString());
        }
    }
}
