using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Membresia
    {
        public int IdMembresia { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public List<object> Membresias { get; set; }
    }
}
