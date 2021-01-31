using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using App_EmpresaDI.Paginas;

namespace App_EmpresaDI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fr_Paginas.Navigate(new pg_Home());
        }

        private void TrabajarBotones(object sender, RoutedEventArgs e)
        {
            BotonesAlternar(sender);
            switch (((ToggleButton)sender).Name)
            {
                case "btn_Home":
                    fr_Paginas.Navigate(new pg_Home());
                    lbTituloSeccion.Content = "HOME";
                    break;
                case "btn_Clientes":
                    fr_Paginas.Navigate(new pg_Clientes());
                    lbTituloSeccion.Content = "CLIENTES";
                    break;
                case "btn_Productos":
                    fr_Paginas.Navigate(new pg_Productos());
                    lbTituloSeccion.Content = "PRODUCTOS";
                    break;
                case "btn_Pedidos":
                    fr_Paginas.Navigate(new pg_Pedidos());
                    lbTituloSeccion.Content = "PEDIDOS";
                    break;
            }
        }

        private void BotonesAlternar(object sender)
        {
            foreach (Control ctl in grid_Botones.Children)
            {
                if(ctl is ToggleButton) ((ToggleButton)ctl).IsChecked = false;
            }
            ((ToggleButton)sender).IsChecked = true;
        }

        private void AjusteFuentes(object sender, SizeChangedEventArgs e)
        {
            lbTitulo.FontSize = this.ActualHeight * 0.05;

            foreach (Control ctl in grid_Botones.Children)
            {
                if (ctl is ToggleButton) ctl.FontSize = this.ActualHeight * 0.02;
                if (ctl is Label) ctl.FontSize = this.ActualHeight * 0.03;
            }
        }
    }
}
