using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using App_EmpresaDI.Paginas;
using LibreriasByJIM;
using LibreriasByJIM.Controles_JIM;
using Capa_Logica;
using System.Windows.Threading;
using System;

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
            DispatcherTimer time = new DispatcherTimer();
            time.Interval = TimeSpan.FromMilliseconds(500);
            time.Tick += Time_Tick;
            time.Start();
        }

        private void Time_Tick(object sender, System.EventArgs e)
        {
            lbFecha.Content = DateTime.Now.ToLongDateString();
            lbHora.Content = DateTime.Now.ToLongTimeString();
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
                    fr_Paginas.Navigate(new pg_DeClientes());
                    lbTituloSeccion.Content = "CLIENTES";
                    break;
                case "btn_Productos":
                    fr_Paginas.Navigate(new pg_DeProductos());
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

        private void TrabajoMenu(object sender, RoutedEventArgs e)
        {
            switch (((MenuItem)sender).Header.ToString())
            {
                case "Salir":
                    this.Close();
                    break;

                case "Eliminar BBDD":
                    myBBDD.EliminarBBDD();
                    break;

                case "Crear BBDD":
                    myBBDD.CrearBBDD();
                    break;
                case "Acerca De":
          
                    break;
            }

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
