using Capa_Logica;
using LibreriasByJIM.Controles_JIM;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace App_EmpresaDI.Paginas
{
    /// <summary>
    /// Lógica de interacción para wid_LineaPedido.xaml
    /// </summary>
    public partial class wid_LineaPedido : Window
    {
        LineaPedido linea; 

        public wid_LineaPedido(LineaPedido linea)
        {
            InitializeComponent();
            cargarProductos();

            if (linea != null)
            {
                this.linea = linea;
                cargarDatos();
            }else
            {
                linea = new LineaPedido();
            }
        }

        private void SalvarDatos(object sender, RoutedEventArgs e)
        {
            if (txtNumLinea.Text == "" || txtCantidad.Text == "")
            {
                new MensajeBox("Faltan datos para poder continuar.");
            }

            linea.NumLin = Convert.ToInt32(txtNumLinea.Text);
            linea.CodProducto = Tb_Productos.dameCodigoProducto(cbProductos.SelectedValue.ToString());
            linea.Cantidad = Convert.ToInt32(txtCantidad.Text);
            linea.Precio = Convert.ToInt32(txtPrecio.Content.ToString());
        }


        private void cargarDatos()
        {
            txtNumLinea.Text = linea.NumLin.ToString();
            txtCantidad.Text = linea.Cantidad.ToString();
            txtPrecio.Content = linea.Precio.ToString();
            foreach(ItemCollection ctl in cbProductos.Items)
            {
                if(ctl.ToString() == linea.CodProducto.ToString())
                {
                    cbProductos.SelectedItem = ctl;
                }
            }           
        }

        private void cargarProductos()
        {
            DataTable dt = Tb_Productos.listadoProductos();

            foreach (DataRow miRow in dt.Rows)
            {
                cbProductos.Items.Add(miRow.ItemArray[1].ToString());
            }
        }


        private void ModificamosDatos(object sender, TextChangedEventArgs e)
        {
            txtPrecio.Content = Convert.ToInt32(txtCantidad.Text) * Tb_Productos.damePrecioProducto(cbProductos.SelectedItem.ToString());
        }
    }
}
