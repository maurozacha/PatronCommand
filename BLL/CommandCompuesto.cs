using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommandCompuesto : ICommand
    {

        private List<ICommand> comandos = new List<ICommand>();

        public void AgregarComando(ICommand comando)
        {
            comandos.Add(comando);
        }

        public void Ejecutar()
        {
            foreach (var comando in comandos)
            {
                comando.Ejecutar();
            }
        }
    }
}
