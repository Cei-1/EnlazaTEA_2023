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
    
    public partial class Cita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cita()
        {
            this.DetallesCitas = new HashSet<DetallesCita>();
        }
    
        public int IdCita { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdEspecialista { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.TimeSpan> Horario { get; set; }
        public Nullable<int> Estatus { get; set; }
        public Nullable<bool> Virtual { get; set; }
        public string Link { get; set; }
        public string Observacion { get; set; }
    
        public virtual Especialista Especialista { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesCita> DetallesCitas { get; set; }
    }
}
