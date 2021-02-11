using Capa_Logica;
using LibreriasByJIM.Controles_JIM;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace App_EmpresaDI.Paginas
{
    /// <summary>
    /// Lógica de interacción para pg_Pedidos.xaml
    /// </summary>
    public partial class pg_Pedidos : Page
    {
        DataTable dt;
        Pedido pedido;
        LineaPedido linea;

        public pg_Pedidos()
        {
            InitializeComponent();
            CargarDatos();

        }


        public void CargarDatos()
        {
            dt = Tb_Clientes.listadoClientes();
            //cbCliente.AddItems("Selecciona cliente");
            foreach (DataRow miRow in dt.Rows)
            {
                cbCliente.AddItems(miRow.ItemArray[1].ToString());
            }


            //cbEstado.AddItems("Selecciona Estado");
            cbEstado.AddItems("En espera");
            cbEstado.AddItems("En proceso");
            cbEstado.AddItems("Listo");


        }


        private void TrabajoConLaTabla(object sender, RoutedEventArgs e)
        {
            dt = Tb_Pedidos.listadoPedidos();
            pedido = new Pedido();
            Int32 filaActual = -1;
            if (lbId.Content == null) lbId.Content = 0;
            for(int i = 0; i< dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[0].ToString() == lbId.Content.ToString())
                {
                    filaActual = i;
                    break;
                }
            }

            switch (((Button)sender).Name)
            {
                case "btnNextReg":
                    filaActual = (filaActual < dt.Rows.Count-1)? filaActual+1 : filaActual;
                    break;
                case "btnPrevReg":
                    filaActual = (filaActual == 0) ? filaActual : filaActual-1;
                    break;
                case "btnFirstReg":
                    filaActual=0;
                    break;
                case "btnLastReg":
                    filaActual = dt.Rows.Count;
                    break;
            }

            lbId.Content = dt.Rows[filaActual].ItemArray[0].ToString();
            txtCodPedido.Texto = dt.Rows[filaActual].ItemArray[1].ToString();
            cbCliente.SeleccionarItem(Tb_Clientes.damePoscionCliente(Convert.ToInt32(dt.Rows[filaActual].ItemArray[2]))+1);
            txtFecha.Fecha = Convert.ToDateTime(dt.Rows[filaActual].ItemArray[3]);
            cbEstado.SeleccionarItem(Convert.ToInt16(dt.Rows[filaActual].ItemArray[4]));
            txtComentario.Texto = dt.Rows[filaActual].ItemArray[5].ToString();
            cargarLineasPedido();
        }

        private void cargarLineasPedido()
        {
            dgv_Lineas.ItemsSource = Tb_Lineas.listadoLineas(Convert.ToInt32(lbId.Content.ToString())).DefaultView;
        }

        private void TrabajoBotones(object sender, RoutedEventArgs e)
        {
            if(ComprobamosDatos())
            { 
                switch (((Button)sender).Name)
                {
                    case "btnAdd":
                        creamosPedido();
                        if (Tb_Pedidos.addPedido(pedido))
                            new MensajeBox("PEDIDO INTRODUCIDO CON EXITO");
                        break;
                    case "btnUpdate":
                        creamosPedido();
                        if (Tb_Pedidos.updatePedido(pedido))
                            new MensajeBox("PEDIDO ACTUALIZADO CON EXITO");
                        break;
                    case "btnDel":
                        creamosPedido();
                        if (Tb_Pedidos.delPedido(pedido))
                            new MensajeBox("PEDIDO ELIMINADO CON EXITO");
                        break;
                   
                }
            }
        }

        private void TrabajoBotonesLineas(object sender, RoutedEventArgs e)
        {
            if (txtCodPedido.Texto == null || txtCodPedido.Texto == txtCodPedido.Hint)
            {
                new MensajeBox("TENEMOS QUE TENER UN PEDIDO SELECCIONADO EN LA PARTE DE PEDIDOS");
            }
            else
            { 

                switch (((Button)sender).Name)
                {
                    case "btnAddLinea":
                        linea = new LineaPedido();
                        linea.Codpedido = Convert.ToUInt16(lbId.Content.ToString());
                        wid_LineaPedido frm = new wid_LineaPedido(linea);
                        frm.ShowDialog();
                        linea = frm.Linea;

                        if (Tb_Lineas.addLineaPedido(linea))
                           new MensajeBox("LINEA INTRODUCIDO CON EXITO");
                        break;
                    case "btnUpdateLinea":
                        if(creamosLinea())
                            if (Tb_Lineas.updateLinea(linea))
                                new MensajeBox("LINEA ACTUALIZADO CON EXITO");
                        break;
                    case "btnDelLinea":
                        if (creamosLinea())
                            if (Tb_Lineas.delLinea(linea))
                                new MensajeBox("LINEA ELIMINADO CON EXITO");
                        break;
                }
                cargarLineasPedido();
            }
        }

        #region TRABAJAMOS LA BBDD

        private Boolean ComprobamosDatos()
        {
            if (txtCodPedido.Texto == "" || txtCodPedido.Texto == txtCodPedido.Hint)
            {
                new MensajeBox("EL CODIGO DEL PEDIDO NO PUEDE ESTAR VACIO");
                return false;
            }
            else if (txtFecha.txtEntrada.Text == "")
            {
                new MensajeBox("LA FECHA DEL PEDIDO NO PUEDE ESTAR VACIA");
                return false;
            }
            else if (cbCliente.Texto == "" || txtComentario.Texto == txtComentario.Hint)
            {
                new MensajeBox("ELIGE EL CLIENTE QUE HACE EL PEDIDO");
                return false;
            }
            else if (cbEstado.Texto == "" || cbEstado.Texto == cbEstado.Hint)
            {
                new MensajeBox("ES OBLIGATORIO EL ESTADO DEL PEDIDO");
                return false;
            }
            return true;
        }

        private void creamosPedido()
        {
            pedido = new Pedido();
            pedido.Codigo = lbId.Content == null ? 0 : Convert.ToInt32(lbId.Content);
            pedido.NumPedido = Convert.ToInt32(txtCodPedido.Texto);
            pedido.CodCliente = Tb_Clientes.dameCodigoCliente(cbCliente.Texto);
            pedido.Fecha = Convert.ToDateTime(txtFecha.Fecha);
            pedido.Estado = cbEstado.ItemSeleccionado();
            pedido.Observaciones = txtComentario.Texto;
        }

        private void LimpiarCampos()
        {
            lbId.Content = "";
            txtCodPedido.Texto = "";
            txtComentario.Texto = "";
            cbCliente.Texto = "";
            cbEstado.Texto = "";
        }

        private Boolean creamosLinea()
        {
            linea = new LineaPedido();
            DataRowView miRow = (DataRowView)dgv_Lineas.SelectedItem;

            if (miRow == null)
            {
                new MensajeBox("NO HAY SELECCIONADO EL LA TABLA");
                return false;
            }
            linea.Id = Convert.ToInt32(miRow["LIN_CODIGO"]);
            linea.NumLin = Convert.ToInt32(miRow["LIN_NUMLIN"]);
            linea.Codpedido = Convert.ToInt32(miRow["LIN_CODPEDIDO"]);
            linea.CodProducto = Convert.ToInt32(miRow["LIN_CODPRODUCTO"]);
            linea.Cantidad = Convert.ToInt32(miRow["LIN_CANTIDAD"]);
            linea.Precio = Convert.ToInt32(miRow["LIN_PRECIO"]);
            return true;
        }


        #endregion


        private void AjusteFuentes(object sender, SizeChangedEventArgs e)
        {
            Double factorFuente = 0.05;
            lbTituloCabecera.FontSize = this.ActualHeight * 0.02;
            lbTituloLineas.FontSize = this.ActualHeight * 0.02;
            txtCodPedido.FontSize = this.ActualHeight * factorFuente;
            cbCliente.FontSize = this.ActualHeight * factorFuente;
            txtFecha.FontSize = this.ActualHeight * factorFuente;
            cbEstado.FontSize = this.ActualHeight * factorFuente;
            txtComentario.FontSize = this.ActualHeight * factorFuente;

            dgv_Lineas.FontSize = this.ActualHeight * 0.03;

            foreach (Button btn in grid_ControlRegistros.Children)           
                ((Button)btn).FontSize = this.ActualHeight * 0.03;
            foreach (Button btn in grid_ControlLineas.Children)
                ((Button)btn).FontSize = this.ActualHeight * 0.03;

        }


    }
}
