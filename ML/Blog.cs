using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Blog
    {
        public int IdBlog { get; set; }

        public string Titulo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public byte[] Imagen { get; set; }
        public ML.Usuario Usuario { get; set; }

        public List<Object> Blogs { get; set; }
    }
}
