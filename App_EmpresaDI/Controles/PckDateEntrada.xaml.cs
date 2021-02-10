using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace App_EmpresaDI.Controles
{
    /// <summary>
    /// Lógica de interacción para PckDateEntrada.xaml
    /// </summary>
    public partial class PckDateEntrada : UserControl, INotifyPropertyChanged
    {
        private ImageSource icono;

        private String frase;

        private String hint;
        private Boolean esNumero;

        private DateTime fecha;



        public PckDateEntrada()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void CargoControl(object sender, RoutedEventArgs e)
        {
            txtEntrada.Text = Hint;
            Frase = txtEntrada.Text;
            txtEntrada.Foreground = Brushes.LightGray;
        }

        private void PierdeFoco(object sender, RoutedEventArgs e)
        {
            if (txtEntrada.Text == "")
            {
                txtEntrada.Text = Hint;
                txtEntrada.Foreground = Brushes.LightGray;
            }

        }

        private void CojoFoco(object sender, RoutedEventArgs e)
        {
            if (txtEntrada.Text == Hint)
            {
                txtEntrada.Text = "";
                txtEntrada.Foreground = Brushes.Black;
            }
        }

        private void ControlEntradaTexto(object sender, KeyEventArgs e)
        {
            if (esNumero)
            {
                if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Decimal)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        private void ajustarFuentes(object sender, SizeChangedEventArgs e)
        {
            txtEntrada.FontSize = this.ActualWidth * 0.06;
        }



        #region PROPIEDADES DE LA CLASE

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ImageSource Icono
        {
            get
            {
                return icono;
            }

            set
            {
                icono = value;
                NotifyPropertyChanged();
            }
        }

        public string Frase
        {
            get
            {
                return frase;
            }

            set
            {
                frase = value;
            }
        }

        public string Hint
        {
            get
            {
                return hint;
            }

            set
            {
                hint = value;
            }
        }

        public bool EsNumero
        {
            get
            {
                return esNumero;
            }

            set
            {
                esNumero = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime Fecha
        {
            get => fecha;
            set
            {
                fecha = value;
                NotifyPropertyChanged();
            }

            #endregion

        }

        private void txtEntrada_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fecha = txtEntrada.DisplayDate;
        }
    }
}
