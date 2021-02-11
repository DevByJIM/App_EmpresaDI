using Capa_Logica;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace App_EmpresaDI.Paginas
{
    /// <summary>
    /// Lógica de interacción para wid_LineaPedido.xaml
    /// </summary>
    public partial class wid_LineaPedido : Window
    {
        LineaPedido linea; 

        public wid_LineaPedido(LineaPedido linea)
        {
            InitializeComponent();

            if (linea != null) this.linea = linea;
        }

        private void cargarDatos()
        {
            DataTable dt = Tb_Productos.listadoProductos();

            foreach(DataRow miRow in dt.Rows)
            {
                cbProductos.Items.Add(miRow.ItemArray[1].ToString());
            }
        }
    }
}
