using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cita
    {
        public int IdCita { get; set; }
        public ML.Usuario Usuario { get; set; }
        public ML.Especialista Especialista { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public int Estatus { get; set; }
    }
}
