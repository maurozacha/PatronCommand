using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contenido
    {
        public int id { get; set; }
        public string titulo { get; set; }

        public string genero { get; set; }

        public TipoSubscripcion tipoSubscripcion { get; set; }
    }
}
