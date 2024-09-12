using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public class SubscribirUsuarioCommand : ICommand
    {
        private readonly Usuario usuario;
        private readonly Subscipcion subscipcion;
        UsuarioBLL usuarioBLL;

        public SubscribirUsuarioCommand()
        {
            usuarioBLL = new UsuarioBLL();
        }

        public SubscribirUsuarioCommand(Usuario usuario, Subscipcion suscripcion)
        {
            this.usuario = usuario;
            this.subscipcion = suscripcion;
        }

        public void Ejecutar()
        {
            // Llamar a la lógica de negocio para suscribir usuario
            usuarioBLL.Suscribir(usuario, subscipcion);
        }

        public void Deshacer()
        {
            // Lógica para deshacer suscripción
            usuarioBLL.CancelarSuscripcion(usuario);

        }
    }
}
