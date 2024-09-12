using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CancelarSubscripcionUsuarioCommand : ICommand
    {

        private readonly Usuario usuario;
        private readonly Subscipcion subscipcion;
        UsuarioBLL usuarioBLL;


        public CancelarSubscripcionUsuarioCommand()
        {

            usuarioBLL = new UsuarioBLL();
        }

        public CancelarSubscripcionUsuarioCommand(Usuario usuario, Subscipcion subscipcion)
        {
            this.usuario = usuario;
            this.subscipcion = subscipcion;
        }

        public void Ejecutar() {
            usuarioBLL.CancelarSuscripcion(usuario);

        }

        public void Deshacer() {
            usuarioBLL.Suscribir(usuario, subscipcion);
        }
    }
}
