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
            Double factorFuente = 0.05;
            txtNombre.FontSize = this.ActualHeight * factorFuente;
            txtDireccion.FontSize = this.ActualHeight * factorFuente;
            txtCiudad.FontSize = this.ActualHeight * factorFuente;
            txtTelefono.FontSize = this.ActualHeight * factorFuente;
            txtObservaciones.FontSize = this.ActualHeight * 0.04;

            foreach (Button btn in grid_Botones.Children)
            {
                ((Button)btn).FontSize = this.ActualHeight * 0.03;
            }
        }

    }
}
