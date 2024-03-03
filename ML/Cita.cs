using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "El campo 'Fecha' es requerido.")]
        [Display(Name = "Fecha *")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo 'Horario' es requerido.")]
        [Display(Name = "Horario *")]
        public TimeSpan Horario { get; set; }

        [Required(ErrorMessage = "El campo 'Estatus' es requerido.")]
        [Display(Name = "Estatus *")]
        public int Estatus { get; set; }
        [Display(Name = "Virtual")]
        public bool Virtual { get; set; }

        [Display(Name = "Link")]
        public string Link { get; set; }

        [Display(Name = "Observación")]
        public string Observacion { get; set; } // Nuevo campo Observacion
        public List<object> Citas { get; set; }
        public ML.DetallesCita Detalles { get; set; }
        public Cita()
        {
            Detalles = new DetallesCita(); // Inicialización del objeto Detalles
        }
    }
}
