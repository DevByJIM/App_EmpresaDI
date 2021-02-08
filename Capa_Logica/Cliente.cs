using System;
using Capa_Datos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LibreriasByJIM.Controles_JIM;

namespace Capa_Logica
{
    public class Cliente
    {
        private String id;
        private String nombre;
        private String direccion;
        private String telefono;
        private String ciudad;
        private String observaciones;

        public Cliente() { }

        public Cliente(string id, string nombre, string direccion, string telefono, string ciudad, string observaciones)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.ciudad = ciudad;
            this.observaciones = observaciones;
        }
        
      

        #region PROPIEDADES
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Ciudad
        {
            get
            {
                return ciudad;
            }

            set
            {
                ciudad = value;
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
        #endregion
    }
}
