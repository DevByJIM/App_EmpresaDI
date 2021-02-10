using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class Pedido
    {
        private Int32 codigo;
        private Int32 numPedido;
        private Int32 codCliente;
        private DateTime fecha;
        private Int32 estado;
        private String observaciones;

        public Pedido()
        {
        }

        public Pedido(int codigo, int numPedido, int codCliente, DateTime fecha, Int32 estado, string observaciones)
        {
            this.codigo = codigo;
            this.numPedido = numPedido;
            this.codCliente = codCliente;
            this.fecha = fecha;
            this.estado = estado;
            this.observaciones = observaciones;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public int NumPedido { get => numPedido; set => numPedido = value; }
        public int CodCliente { get => codCliente; set => codCliente = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Int32 Estado { get => estado; set => estado = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
    }
}
