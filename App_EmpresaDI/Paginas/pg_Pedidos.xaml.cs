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
    /// Lógica de interacción para pg_Pedidos.xaml
    /// </summary>
    public partial class pg_Pedidos : Page
    {
        public pg_Pedidos()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {

        }

        private void AjusteFuentes(object sender, SizeChangedEventArgs e)
        {
            Double factorFuente = 0.05;
            lbTituloCabecera.FontSize = this.ActualHeight * 0.02;
            lbTituloLineas.FontSize = this.ActualHeight * 0.02;
            txt_CodPedido.FontSize = this.ActualHeight * factorFuente;
            txt_Cliente.FontSize = this.ActualHeight * factorFuente;
            txt_Fecha.FontSize = this.ActualHeight * factorFuente;
            txt_Estado.FontSize = this.ActualHeight * factorFuente;
            txt_Comentario.FontSize = this.ActualHeight * factorFuente;

            foreach (Button btn in grid_ControlRegistros.Children)           
                ((Button)btn).FontSize = this.ActualHeight * 0.03;
            foreach (Button btn in grid_ControlLineas.Children)
                ((Button)btn).FontSize = this.ActualHeight * 0.03;

        }
    }
}
