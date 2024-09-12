using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace Mapper
{
    public class UsuarioMapper
    {
        Datos datos;
        Hashtable hashtable;

        public UsuarioMapper()
        {
            datos = new Datos();
        }


        public void SuscribirUsuario(Usuario usuario, Subscipcion subscripcion)
        {
            Hashtable parametros = new Hashtable
        {
            { "@usuarioID", usuario.id },
            { "@subscripcionID", subscripcion.id }
        };

            datos.EjecutarComando("Suscribir_Usuario", parametros);
        }

        // Método para cancelar la suscripción de un usuario
        public void CancelarSuscripcion(Usuario usuario)
        {
            Hashtable parametros = new Hashtable
        {
            { "@usuarioID", usuario.id }
        };

            datos.EjecutarComando("Cancelar_Suscripcion", parametros);
        }

        // Método para verificar si un usuario tiene una suscripción activa
        public bool EsSuscripcionActiva(Usuario usuario)
        {
            Hashtable parametros = new Hashtable
        {
            { "@usuarioID", usuario.id }
        };

            object resultado = datos.EjecutarScalar("Es_Suscripcion_Activa", parametros);
            return Convert.ToBoolean(resultado);
        }
    }
}
