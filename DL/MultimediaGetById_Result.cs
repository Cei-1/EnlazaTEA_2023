
namespace DL
{
    using System;
    
    public partial class MultimediaGetById_Result
    {
        public int IdMultimedia { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public byte[] Imagen { get; set; }
        public string Tipo { get; set; }
        public string VideoID { get; set; }
        public byte[] Audio { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    }
}
