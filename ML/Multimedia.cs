using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Multimedia
    {
        public int IdMultimedia { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }

        public byte[] Imagen { get; set; }
        public string Tipo { get; set; }
        public string VideoID { get; set; }
        public byte[] Audio { get; set; }

        public ML.Usuario Usuario { get; set; }

        public List<Object> Multimedias { get; set; }
    }
}
