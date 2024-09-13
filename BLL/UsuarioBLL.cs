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

        public void Suscribir(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentException("Usuario o suscripción no pueden ser nulos.");
            }

            usuarioMapper.AgregarUsuario(usuario);
        }

        public void CancelarSuscripcion(Usuario usuario,Subscripcion subscripcion)
        {
            if (usuario == null)
            {
                throw new ArgumentException("El usuario no puede ser nulo.");
            }

            usuarioMapper.CancelarSuscripcion(usuario, subscripcion);
        }

        public List<Usuario> ObtenerUsuariosConSuscripciones()
        {
           return usuarioMapper.ObtenerUsuariosConSuscripciones();
        }

        public Usuario ObtenerUsuarioPorNombre(string nomUsuario)
        {
            return usuarioMapper.ObtenerUsuarioPorNombre(nomUsuario);
        }

        public Subscripcion ObtenerSubscripcionPorTipo(string tipo)
        {
            return usuarioMapper.ObtenerSubscripcionPorTipo(tipo);
        }

        public void AgregarUsuarioConSubscripcion(Usuario usuario)
        {
            Subscripcion subscripcion = usuarioMapper.ObtenerSubscripcionPorTipo(usuario.subscripcion.tipoSubscripcion.nombre);

            if (subscripcion == null)
            {
                throw new Exception("No se pudo encontrar el tipo de suscripción.");
            }

            usuario.subscripcion.id = subscripcion.id;

            usuarioMapper.AgregarUsuario(usuario);
        }

        public List<TipoSubscripcion> ObtenerTiposSubscripcion()
        {
            return usuarioMapper.ObtenerTiposSubscripcion();
        }

        public string NotificarUsuario(Usuario usuario)
        {

            return $"El usuario {usuario.nomUsuario} fue notificado de la cancelacion de la subscripcion al correo: {usuario.mail}";
        }
    }
}
