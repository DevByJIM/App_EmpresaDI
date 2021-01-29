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
        }

        private void TrabajarBotones(object sender, RoutedEventArgs e)
        {
            BotonesAlternar(sender);
            switch (((ToggleButton)sender).Name)
            {
                case "btn_Home":
                    //fr_Paginas.Navigate(new pg_Home());
                    break;
                case "btn_Clientes":
                    fr_Paginas.Navigate(new pg_Clientes());
                    break;
                case "btn_Productos":
                    //fr_Paginas.Navigate(new pg_Productos());
                    break;
                case "btn_Ventas":
                    //fr_Paginas.Navigate(new pg_Ventas());
                    break;
            }
        }

        private void BotonesAlternar(object sender)
        {
            foreach (ToggleButton btn in grid_Botones.Children)
            {
                btn.IsChecked = false;
            }
            ((ToggleButton)sender).IsChecked = true;
        }

        private void AjusteFuentes(object sender, SizeChangedEventArgs e)
        {
            lbTitulo.FontSize = this.ActualHeight * 0.05;

            foreach (ToggleButton btn in grid_Botones.Children)
            {
                btn.FontSize = this.ActualHeight * 0.02;
            }
        }
    }
}
