using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NotificarCancelacionSubscripcionCommand : ICommand
    {
        private  Receiver receiver;
        private string mensajeNotificacion;


        public NotificarCancelacionSubscripcionCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Ejecutar()
        {
            mensajeNotificacion = receiver.NotificarUsuario();
        }

        public string ObtenerMensajeNotificacion()
        {
            return mensajeNotificacion;
        }
    }
}
