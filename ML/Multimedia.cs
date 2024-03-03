using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Multimedia
    {
        public int IdMultimedia { get; set; }

        [Required(ErrorMessage = "El campo 'Título' es requerido.")]
        [Display(Name = "Título *")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo 'Contenido' es requerido.")]
        [Display(Name = "Contenido *")]
        public string Contenido { get; set; }

        [Display(Name = "Imagen")]
        public byte[] Imagen { get; set; }

        [Required(ErrorMessage = "El campo 'Tipo' es requerido.")]
        [Display(Name = "Tipo *")]
        public string Tipo { get; set; }

        [Display(Name = "ID del Video")]
        public string VideoID { get; set; }

        [Display(Name = "Audio")]
        public byte[] Audio { get; set; }

        public ML.Usuario Usuario { get; set; }

        public ML.Like Like { get; set; }
        public List<object> Multimedias { get; set; }
    }
}
