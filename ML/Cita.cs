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
        public bool Virtual { get; set; }
        public string Link { get; set; } // Nuevo campo Link
        public string Observacion { get; set; } // Nuevo campo Observacion
        public List<object> Citas { get; set; }
        public ML.DetallesCita Detalles { get; set; }
        public Cita()
        {
            Detalles = new DetallesCita(); // Inicialización del objeto Detalles
        }
    }
}
