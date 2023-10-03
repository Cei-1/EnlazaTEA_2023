using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Pago
    {
        public int IdPago { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaProximoPago { get; set; }
        public ML.Especialista Especialista { get; set; }
        public ML.Membresia Membresia { get; set; }
        public List<object> Pagos { get; set; }
    }
}
