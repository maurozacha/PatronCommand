using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Mapper;

namespace BLL
{
    public class UsuarioBLL
    {
        UsuarioMapper usuarioMapper;
        public UsuarioBLL()
        {
            usuarioMapper = new UsuarioMapper();
        }

        public void Suscribir(Usuario usuario, Subscipcion suscripcion)
        {
            if (usuario == null || suscripcion == null)
            {
                throw new ArgumentException("Usuario o suscripción no pueden ser nulos.");
            }

            usuarioMapper.SuscribirUsuario(usuario, suscripcion);
        }

        public void CancelarSuscripcion(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentException("El usuario no puede ser nulo.");
            }

            usuarioMapper.CancelarSuscripcion(usuario);
        }

        public void Reproducir(Usuario usuario, Contenido contenido)
        {
            if (usuario == null || contenido == null)
            {
                throw new ArgumentException("Usuario o contenido no pueden ser nulos.");
            }

            // Aquí podríamos implementar lógica para validar la reproducción, como:
            // - Verificar si el usuario tiene una suscripción activa.
            // - Registrar la reproducción del contenido.

            
        }

        public static void DetenerReproduccion(Usuario usuario, Contenido contenido)
        {
            if (usuario == null || contenido == null)
            {
                throw new ArgumentException("Usuario o contenido no pueden ser nulos.");
            }

            // Aquí podríamos implementar lógica para detener la reproducción.

        }
    }
}
