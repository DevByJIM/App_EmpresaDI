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

namespace App_EmpresaDI.Controles
{
    /// <summary>
    /// Lógica de interacción para TextEntradaWrap.xaml
    /// </summary>
    public partial class TextEntradaWrap : UserControl
    {
        private ImageSource icono;

        private String frase;

        private String hint;

        public TextEntradaWrap()
        {
            InitializeComponent();
            this.DataContext = this;
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtEntrada.Text = Hint;
            Frase = txtEntrada.Text;
            txtEntrada.Foreground = Brushes.LightGray;
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

        #endregion



    }
}
