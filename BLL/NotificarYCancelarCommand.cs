using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NotificarYCancelarCommand : ICommand
    {

        private readonly CommandCompuesto commandCompuesto;
        private NotificarCancelacionSubscripcionCommand notificarCommand;

        public NotificarYCancelarCommand(Receiver receiver)
        {
            commandCompuesto = new CommandCompuesto();
            var cancelarCommand = new CancelarSubscripcionUsuarioCommand(receiver);
            notificarCommand = new NotificarCancelacionSubscripcionCommand(receiver);

            commandCompuesto.AgregarComando(cancelarCommand);
            commandCompuesto.AgregarComando(notificarCommand);
        }

        public void Ejecutar()
        {
            commandCompuesto.Ejecutar();
        }

        public string ObtenerMensajeNotificacion()
        {
            return notificarCommand.ObtenerMensajeNotificacion();
        }

    }
}
