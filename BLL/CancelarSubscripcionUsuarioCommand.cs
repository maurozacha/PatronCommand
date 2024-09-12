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

        private readonly Receiver receiver;

        public CancelarSubscripcionUsuarioCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Ejecutar()
        {
            receiver.CancelarSuscripcion();
        }

    }
}
