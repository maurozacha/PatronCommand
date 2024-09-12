using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TipoSubscripcion
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public List<Contenido> contenidos { get; set; }
    }
}
