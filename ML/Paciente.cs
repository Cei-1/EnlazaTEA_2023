using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        [Required(ErrorMessage = "El campo 'Nombre' es requerido.")]
        [Display(Name = "Nombre *")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo 'Apellido Paterno' es requerido.")]
        [Display(Name = "Apellido Paterno *")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El campo 'Apellido Materno' es requerido.")]
        [Display(Name = "Apellido Materno *")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El campo 'Parentesco' es requerido.")]
        [Display(Name = "Parentesco *")]
        public string Parentesco { get; set; }
        public int NivelTEA { get; set; }
        [Required(ErrorMessage = "El campo 'Sexo' es requerido.")]
        [Display(Name = "Sexo *")]
        public bool Sexo { get; set; }

        [Required(ErrorMessage = "El campo 'Edad' es requerido.")]
        [Display(Name = "Edad *")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo 'Calle' es requerido.")]
        [Display(Name = "Calle *")]
        public string Calle { get; set; }

        [Display(Name = "Número Exterior")]
        public string NumeroExterior { get; set; }

        [Display(Name = "Número Interior")]
        public string NumeroInterior { get; set; }

        [Required(ErrorMessage = "El campo 'Colonia' es requerido.")]
        [Display(Name = "Colonia *")]
        public string Colonia { get; set; }

        [Required(ErrorMessage = "El campo 'Municipio' es requerido.")]
        [Display(Name = "Municipio *")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "El campo 'Estado' es requerido.")]
        [Display(Name = "Estado *")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo 'Código Postal' es requerido.")]
        [Display(Name = "Código Postal *")]
        public string CP { get; set; }

        [Required(ErrorMessage = "El campo 'Escolaridad' es requerido.")]
        [Display(Name = "Escolaridad *")]
        public string Escolaridad { get; set; }
        public int Evaluacion { get; set; }
        public ML.Usuario Usuario { get; set; }
        public List<Paciente> Pacientes { get; set; }
    }
}
