using ControlesByJIM;
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
    public partial class pg_Productos : Page
    {
        public pg_Productos()
        {
            InitializeComponent();
        }

        private void TrabajoBotones(object sender, RoutedEventArgs e)
        {
            ComprobamosDatos();
            switch (((Button)sender).Name)
            {
                case "btnAdd":
                    new wid_MessageBox("PRODUCTO INTRODUCIDO CON EXITO");
                    break;
                case "btnupdate":
                    new wid_MessageBox("PRODUCTO ACTUALIZADO CON EXITO");
                    break;
                case "btnDel":
                    new wid_MessageBox("PRODUCTO ELIMINADO CON EXITO");
                    break;
            }
        }

        private void ComprobamosDatos()
        {
            if(txtCodigo.Frase =="" || txtCodigo.Frase == txtCodigo.Hint)
            {
                new wid_MessageBox("EL CODIGO DEL PRODUCTO NO PUEDE ESTAR VACIO");
            }
            else if (txtNombre.Frase == "" || txtNombre.Frase == txtNombre.Hint)
            {
                new wid_MessageBox("EL NOMBRE DEL PRODUCTO NO PUEDE ESTAR VACIO");
            }
            else if (txtDescripcion.Frase == "" || txtDescripcion.Frase == txtDescripcion.Hint)
            {
                new wid_MessageBox("LA DESCRIPCION DEL PRODUCTO NO PUEDE ESTAR VACIO");
            }
            else if (txtStock.Frase == "" || txtStock.Frase == txtStock.Hint)
            {
                new wid_MessageBox("EL STOCK DEL PRODUCTO NO PUEDE ESTAR VACIO");
            }
            else if (txtPrecio.Frase == "" || txtPrecio.Frase == txtPrecio.Hint)
            {
                new wid_MessageBox("EL PRECIO DEL PRODUCTO NO PUEDE ESTAR VACIO");
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
