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
        private readonly Receiver receiver;

        public SubscribirUsuarioCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Ejecutar()
        {
            receiver.SuscribirUsuario();
        }
    }
}
