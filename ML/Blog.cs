using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Blog
    {
        public int IdBlog { get; set; }

        [Required(ErrorMessage = "El campo 'Título' es requerido.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo 'Nombre' es requerido.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo 'Descripción' es requerido.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Imagen")]
        public byte[] Imagen { get; set; }

        public ML.Usuario Usuario { get; set; }

        public List<Object> Blogs { get; set; }
    }
}
