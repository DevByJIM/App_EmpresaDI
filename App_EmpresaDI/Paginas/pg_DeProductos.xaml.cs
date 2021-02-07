using LibreriasByJIM.Controles_JIM;
using System;
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

namespace App_EmpresaDI.Paginas
{
    /// <summary>
    /// Lógica de interacción para pg_Productos.xaml
    /// </summary>
    public partial class pg_DeProductos : Page
    {
        public pg_DeProductos()
        {
            InitializeComponent();
        }

        private void TrabajoBotones(object sender, RoutedEventArgs e)
        {
            ComprobamosDatos();
            switch (((Button)sender).Name)
            {
                case "btnAdd":
                    new MensajeBox("PRODUCTO INTRODUCIDO CON EXITO");
                    break;
                case "btnupdate":
                    new MensajeBox("PRODUCTO ACTUALIZADO CON EXITO");
                    break;
                case "btnDel":
                    new MensajeBox("PRODUCTO ELIMINADO CON EXITO");
                    break;
            }
        }

        private void ComprobamosDatos()
        {
            if(txtCodigo.Frase =="" || txtCodigo.Frase == txtCodigo.Hint)
            {
                new MensajeBox("EL CODIGO DEL PRODUCTO NO PUEDE ESTAR VACIO");
            }
            else if (txtNombre.Frase == "" || txtNombre.Frase == txtNombre.Hint)
            {
                new MensajeBox("EL NOMBRE DEL PRODUCTO NO PUEDE ESTAR VACIO");
            }
            else if (txtDescripcion.Frase == "" || txtDescripcion.Frase == txtDescripcion.Hint)
            {
                new MensajeBox("LA DESCRIPCION DEL PRODUCTO NO PUEDE ESTAR VACIO");
            }
            else if (txtStock.Frase == "" || txtStock.Frase == txtStock.Hint)
            {
                new MensajeBox("EL STOCK DEL PRODUCTO NO PUEDE ESTAR VACIO");
            }
            else if (txtPrecio.Frase == "" || txtPrecio.Frase == txtPrecio.Hint)
            {
                new MensajeBox("EL PRECIO DEL PRODUCTO NO PUEDE ESTAR VACIO");
            }
        }


        private void AjusteFuentes(object sender, SizeChangedEventArgs e)
        {
            Double factorFuente = 0.05;
            txtCodigo.FontSize = this.ActualHeight * factorFuente;
            txtNombre.FontSize = this.ActualHeight * factorFuente;
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
