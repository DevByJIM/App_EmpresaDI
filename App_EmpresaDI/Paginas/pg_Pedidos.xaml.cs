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
        }

        private void AjusteFuentes(object sender, SizeChangedEventArgs e)
        {
            //Double factorFuente = 0.05;
            lbTituloCabecera.FontSize = this.ActualHeight * 0.02;
            lbTituloLineas.FontSize = this.ActualHeight * 0.02;
            //txtCodigo.FontSize = this.ActualHeight * factorFuente;
            //cbNombre.FontSize = this.ActualHeight * factorFuente;
            //dtp_Fecha.FontSize = this.ActualHeight * factorFuente;
            //txtComentarios.FontSize = this.ActualHeight * factorFuente;
            //cbEstado.FontSize = this.ActualHeight * factorFuente;
            //txtObservaciones.FontSize = this.ActualHeight * 0.04;

            //foreach (Button btn in grid_Botones.Children)
            //{
            //    ((Button)btn).FontSize = this.ActualHeight * 0.03;
            //}
        }
    }
}
