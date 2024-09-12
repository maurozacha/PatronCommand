using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Subscripcion
    {
        public int id { get; set; }

        public bool activa { get; set; }

        public TipoSubscripcion tipoSubscripcion { get; set; }

        public override string ToString()
        {
            return tipoSubscripcion?.ToString();

        }
    }
}
