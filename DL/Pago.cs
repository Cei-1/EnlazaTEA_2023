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
    
    public partial class Pago
    {
        public int IdPago { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
        public Nullable<System.DateTime> FechaProximoPago { get; set; }
        public Nullable<int> IdEspecialista { get; set; }
        public Nullable<int> IdMembresia { get; set; }
    
        public virtual Especialista Especialista { get; set; }
        public virtual Membresia Membresia { get; set; }
    }
}
