using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Like
    {
        public int IdLike { get; set; }
        public bool IsLike { get; set; }

        public ML.Usuario Usuario { get; set; }
        public ML.Multimedia Multimedia { get; set; }

        public List<object> MeGusta { get; set; }
        // Nuevo atributo para indicar si el usuario actual dio like
        public bool UsuarioDioLike { get; set; }

        // Nuevo atributo para almacenar la cantidad de likes para un multimedia
        public int CantidadLikes { get; set; }
    }
}
