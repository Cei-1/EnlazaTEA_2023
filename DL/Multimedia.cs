//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Multimedia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Multimedia()
        {
            this.Likes = new HashSet<Like>();
        }
    
        public int IdMultimedia { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public byte[] Imagen { get; set; }
        public string Tipo { get; set; }
        public string VideoID { get; set; }
        public byte[] Audio { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like> Likes { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
