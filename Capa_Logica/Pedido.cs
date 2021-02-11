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

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public int NumPedido
        {
            get
            {
                return numPedido;
            }

            set
            {
                numPedido = value;
            }
        }

        public int CodCliente
        {
            get
            {
                return codCliente;
            }

            set
            {
                codCliente = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return observaciones;
            }

            set
            {
                observaciones = value;
            }
        }

        public Pedido()
        {
        }

        public Pedido(int codigo, int numPedido, int codCliente, DateTime fecha, Int32 estado, string observaciones)
        {
            this.Codigo = codigo;
            this.NumPedido = numPedido;
            this.CodCliente = codCliente;
            this.Fecha = fecha;
            this.Estado = estado;
            this.Observaciones = observaciones;
        }


    }
}
