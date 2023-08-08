
namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Multimedia
    {
        public int IdMultimedia { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public byte[] Imagen { get; set; }
        public string Tipo { get; set; }
        public string VideoID { get; set; }
        public byte[] Audio { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
