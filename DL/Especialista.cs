//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Especialista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Especialista()
        {
            this.Citas = new HashSet<Cita>();
            this.Pagoes = new HashSet<Pago>();
        }
    
        public int IdEspecialista { get; set; }
        public string NombreCarrera { get; set; }
        public string NoCedula { get; set; }
        public string Especialidad { get; set; }
        public string Calle { get; set; }
        public string NumeroExterno { get; set; }
        public string NumeroInterno { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public Nullable<bool> Estatus { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public string Colonia { get; set; }
        public string Celular { get; set; }
        public byte[] Comprobante { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Citas { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago> Pagoes { get; set; }
    }
}
