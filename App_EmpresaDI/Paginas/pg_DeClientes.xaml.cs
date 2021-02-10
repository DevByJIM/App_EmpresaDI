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
                        MessageBoxResult respuesta = new MensajeBox("ESTA OPERACION NO TIENE MARCHA ATRÁS.", BOTONES.ACEPTARCANCEL).Respuesta;
                        if (respuesta == MessageBoxResult.OK)
                        {
                            creamosCliente();
                            if (Tb_Clientes.delCliente(cliente))
                                new MensajeBox("CLIENTE ELIMINADO CON EXITO");
                            LimpiarCampos();
                        }

                        break;
                }
                CargamosDatos();
            }
        }


        #region TRABAJAMOS LA BBDD

        private Boolean ComprobamosDatos()
        {
            if (txtNombre.Texto == "" || txtNombre.Texto == txtNombre.Hint)
            {
                new MensajeBox("EL NOMBRE DEL CLIENTE NO PUEDE ESTAR VACIO");
                return false;
            }
            else if (txtTelefono.Texto == "" || txtTelefono.Texto == txtTelefono.Hint)
            {
                new MensajeBox("EL TELEFONO DEL CLIENTE NO PUEDE ESTAR VACIO");
                return false;
            }
            else if (txtDireccion.Texto == "" || txtDireccion.Texto == txtDireccion.Hint)
            {
                new MensajeBox("LA DIRECCION DEL CLIENTE NO PUEDE ESTAR VACIO");
                return false;
            }
            else if (txtCiudad.Texto == "" || txtCiudad.Texto == txtCiudad.Hint)
            {
                new MensajeBox("LA CIUDAD DEL CLIENTE NO PUEDE ESTAR VACIO");
                return false;
            }
            return true;
        }

        private void creamosCliente()
        {
            cliente = new Cliente();
            cliente.Id = lbId.Content==null? "0" : lbId.Content.ToString();
            cliente.Nombre = txtNombre.Texto;
            cliente.Telefono = txtTelefono.Texto;
            cliente.Direccion = txtDireccion.Texto;
            cliente.Ciudad = txtCiudad.Texto;
            cliente.Observaciones = txtObservaciones.Texto;
        }

        private void CargaInformacion(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataRowView miRow = (DataRowView)dgv_Clientes.SelectedItem;
            lbId.Content = (miRow["CLI_CODIGO"].ToString());
            txtNombre.Texto = (miRow["CLI_NOMBRE"].ToString());
            txtTelefono.Texto = (miRow["CLI_TELEFONO"].ToString());
            txtDireccion.Texto = (miRow["CLI_DIRECCION"].ToString());
            txtCiudad.Texto = (miRow["CLI_CIUDAD"].ToString());
            txtObservaciones.Texto = (miRow["CLI_OBSERV"].ToString());
        }

        private void LimpiarCampos()
        {
            lbId.Content = "";
            txtNombre.Texto = "";
            txtTelefono.Texto = "";
            txtDireccion.Texto = "";
            txtCiudad.Texto = "";
            txtObservaciones.Texto = "";
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

            dgv_Clientes.FontSize = this.ActualHeight * 0.03;

            foreach (Button btn in grid_Botones.Children)
            {
                ((Button)btn).FontSize = this.ActualHeight * 0.03;
            }
        }
        #endregion


    }
}
