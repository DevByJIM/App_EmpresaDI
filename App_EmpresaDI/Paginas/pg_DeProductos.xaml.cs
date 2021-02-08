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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App_EmpresaDI.Paginas
{
    /// <summary>
    /// Lógica de interacción para pg_Productos.xaml
    /// </summary>
    public partial class pg_DeProductos : Page
    {
        Producto producto;
        public pg_DeProductos()
        {
            InitializeComponent();
            //cargarDatos();
        }

        private void CargamosDatos()
        {
            DataTable dt = Tb_Clientes.listadoClientes();

            if (dt != null)
                dgv_Productos.ItemsSource = dt.DefaultView;
        }

        private void TrabajoBotones(object sender, RoutedEventArgs e)
        {
            if (ComprobamosDatos())
            {
                switch (((Button)sender).Name)
                {
                    case "btnAdd":
                        creamosProducto();
                        if (Tb_Productos.addProducto(producto))
                            new MensajeBox("PRODUCTO INTRODUCIDO CON EXITO");
                        break;
                    case "btnupdate":
                        creamosProducto();
                        if (Tb_Productos.updateProducto(producto))
                            new MensajeBox("PRODUCTO ACTUALIZADO CON EXITO");
                        break;
                    case "btnDel":
                        creamosProducto();
                        if (Tb_Productos.delProducto(producto))
                            new MensajeBox("PRODUCTO ELIMINADO CON EXITO");
                        break;
                }
            }
        }

        private Boolean ComprobamosDatos()
        {
            if(txtNSerie.Texto =="" || txtNSerie.Texto == txtNSerie.Hint)
            {
                new MensajeBox("EL Nº DE SERIE DEL PRODUCTO NO PUEDE ESTAR VACIO");
                return false;
            }
            else if (txtDescripcion.Texto == "" || txtDescripcion.Texto == txtDescripcion.Hint)
            {
                new MensajeBox("LA DESCRIPCION DEL PRODUCTO NO PUEDE ESTAR VACIO");
                return false;
            }
            else if (txtStock.Texto == "" || txtStock.Texto == txtStock.Hint)
            {
                new MensajeBox("EL STOCK DEL PRODUCTO NO PUEDE ESTAR VACIO");
                return false;
            }
            else if (txtPrecio.Texto == "" || txtPrecio.Texto == txtPrecio.Hint)
            {
                new MensajeBox("EL PRECIO DEL PRODUCTO NO PUEDE ESTAR VACIO");
                return false;
            }
            return true;
        }

        private void creamosProducto()
        {
            producto = new Producto();
            producto.NSerie = txtNSerie.Texto;
            producto.Descripcion = txtDescripcion.Texto;
            producto.Stock = Convert.ToInt32(txtStock.Texto);
            producto.Precio = Convert.ToDouble(txtPrecio.Texto);
            producto.Observaciones = txtObservaciones.Texto;
        }
        private void CargaInformacion(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataRowView miRow = (DataRowView)dgv_Productos.SelectedItem;
            txtNSerie.Texto = (miRow["PRD_NSERIE"].ToString());
            txtDescripcion.Texto = (miRow["PRD_DESCRIPCION"].ToString());
            txtStock.Texto = (miRow["PRD_STOCK"].ToString());
            txtPrecio.Texto = (miRow["PRD_PRECIO"].ToString());
            txtObservaciones.Texto = (miRow["PRD_OBSERV"].ToString());
        }



        private void AjusteFuentes(object sender, SizeChangedEventArgs e)
        {
            Double factorFuente = 0.05;
            txtNSerie.FontSize = this.ActualHeight * factorFuente;
            txtDescripcion.FontSize = this.ActualHeight * factorFuente;
            txtStock.FontSize = this.ActualHeight * factorFuente;
            txtPrecio.FontSize = this.ActualHeight * factorFuente;
            txtObservaciones.FontSize = this.ActualHeight * 0.04;

            foreach (Button btn in grid_Botones.Children)
            {
                ((Button)btn).FontSize = this.ActualHeight * 0.03;
            }
        }
    }
}
