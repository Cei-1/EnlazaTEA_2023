using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class DetallesCita
    {
        public int IdDetallesCita { get; set; }

        public string Observaciones { get; set; }
        public Cita Cita { get; set; }
    }
}
