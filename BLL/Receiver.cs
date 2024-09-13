using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Receiver
    {
        UsuarioBLL usuarioBLL;
        Usuario usuario;
        Subscripcion subscripcion;

        public Receiver(Usuario usuario, Subscripcion subscripcion)
        {
            usuarioBLL = new UsuarioBLL();
            this.usuario = usuario;
            this.subscripcion = subscripcion;
        }

        public void CancelarSuscripcion()
        {
            usuarioBLL.CancelarSuscripcion(usuario, subscripcion);
        }

        public void SuscribirUsuario()
        {
            usuarioBLL.Suscribir(usuario);
        }

        public string NotificarUsuario()
        {
            return usuarioBLL.NotificarUsuario(usuario);
        }
    }
}
