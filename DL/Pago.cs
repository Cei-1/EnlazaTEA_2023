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
    
    public partial class Pago
    {
        public int IdPago { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
        public Nullable<System.DateTime> FechaProximoPago { get; set; }
        public Nullable<int> IdEspecialista { get; set; }
        public Nullable<int> IdMembresia { get; set; }
    
        public virtual Membresia Membresia { get; set; }
        public virtual Especialista Especialista { get; set; }
    }
}
