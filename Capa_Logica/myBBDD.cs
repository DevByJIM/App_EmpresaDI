using Capa_Datos;
using LibreriasByJIM.Controles_JIM;
using System.Windows;
using System;

namespace Capa_Logica
{
    public class myBBDD
    {
        public static void CrearBBDD()
        {
            try
            {
                if (miBBDD.CrearBaseDatos())
                {
                    new MensajeBox("BBDD EMPRESADI CREADA CORRECTAMENTE");
                }
            }
            catch (Exception ex)
            {
                new MensajeBox("PROBLEMAS AL CREAR LA BASE DE DATOS", ex);
            }
              
        }

        public static void EliminarBBDD()
        {
            try
            {
                var respuesta = new MensajeBox("SEGURO QUE QUIERES ELIMINAR TODA LA BASE DE DATOS??", BOTONES.ACEPTARCANCEL).Respuesta;
                if(respuesta == MessageBoxResult.OK)
                {
                    miBBDD.EjecutarOrdenSQL("DROP DATABASE EMPRESADI");
                }
                
            }
            catch (Exception ex)
            {
                new MensajeBox("PROBLEMAS AL ELIMINAR LA BASE DE DATOS", ex);
            }

        }
    }
}
