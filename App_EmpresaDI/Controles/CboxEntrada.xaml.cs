﻿using System;
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
    /// Lógica de interacción para CboxEntrada.xaml
    /// </summary>
    public partial class CboxEntrada : UserControl
    {
        private ImageSource icono;

        private String texto;

        private String hint;
        private Boolean esNumero;

        public CboxEntrada()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void CargoControl(object sender, RoutedEventArgs e)
        {
            txtEntrada.Text = Hint;
            Texto = txtEntrada.Text;
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

        public string Texto
        {
            get
            {
                return texto;
            }

            set
            {
                texto = value;
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
