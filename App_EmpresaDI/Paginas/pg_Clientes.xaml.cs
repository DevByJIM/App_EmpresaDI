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
    /// Lógica de interacción para pg_Clientes.xaml
    /// </summary>
    public partial class pg_Clientes : Page
    {
        public pg_Clientes()
        {
            InitializeComponent();
        }

        private void ControlEntradas(object sender, TextChangedEventArgs e)
        {

        }


        private void AjusteFuentes(object sender, SizeChangedEventArgs e)
        {
            lb_Titulo.FontSize = this.ActualHeight * 0.13;

            //foreach (Control ctl in grid_Datos.Children)
            //{
            //    if (ctl is TextBox) ctl.FontSize = this.ActualHeight * 0.05;
            //}
        }

    }
}
