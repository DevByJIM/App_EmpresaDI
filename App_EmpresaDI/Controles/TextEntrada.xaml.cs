using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace App_EmpresaDI.Controles
{
    /// <summary>
    /// Lógica de interacción para TextEntrada.xaml
    /// </summary>
    public partial class TextEntrada : UserControl
    {
        private ImageSource icono;

        private String frase;

        private String hint;
        private Boolean esNumero;

        public TextEntrada()
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
                if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Decimal || e.Key == Key.Tab)
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
        public ImageSource Icono
        {
            get
            {
                return icono;
            }

            set
            {
                icono = value;
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
            }
        }

        #endregion


    }
}
