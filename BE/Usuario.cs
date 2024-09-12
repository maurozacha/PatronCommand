using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string nomUsuario { get; set; }

        public string mail { get; set; }

        public int edad { get; set; }

        public Subscipcion subscipcion { get; set; }

    }
}
