using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Subscipcion
    {
        public int id { get; set; }
        public DateTime fechaInicio { get; set; }

        public DateTime fechaFin { get; set; }

        public bool activa { get; set; }

        public TipoSubscripcion tipoSubscripcion { get; set; }

    }
}
