using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Especialista
    {
        public int IdEspecialista { get; set; }
        [Required(ErrorMessage = "El campo 'Nombre de Carrera' es requerido.")]
        [Display(Name = "Nombre de Carrera *")]
        public string NombreCarrera { get; set; }

        [Required(ErrorMessage = "El campo 'Número de Cédula' es requerido.")]
        [Display(Name = "Número de Cédula *")]
        public string NoCedula { get; set; }

        //[Required(ErrorMessage = "El campo 'Especialidad' es requerido.")]
        [Display(Name = "Especialidad")]
        public string Especialidad { get; set; }

        [Required(ErrorMessage = "El campo 'Calle' es requerido.")]
        [Display(Name = "Calle *")]
        public string Calle { get; set; }

        [Display(Name = "Número Externo")]
        public string NumeroExterno { get; set; }

        [Display(Name = "Número Interno")]
        public string NumeroInterno { get; set; }

        [Required(ErrorMessage = "El campo 'Colonia' es requerido.")]
        [Display(Name = "Colonia *")]
        public string Colonia { get; set; }

        [Required(ErrorMessage = "El campo 'Ciudad' es requerido.")]
        [Display(Name = "Ciudad *")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El campo 'Estado' es requerido.")]
        [Display(Name = "Estado *")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo 'Código Postal' es requerido.")]
        [Display(Name = "Código Postal *")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "El campo 'Teléfono' es requerido.")]
        [Display(Name = "Teléfono Local *")]
        public string Telefono { get; set; }

        [Display(Name = "Teléfono Movil o Celular")]
        public string Celular { get; set; } // Nuevo campo Celular
        public bool Estatus { get; set; }
        public ML.Usuario Usuario { get; set; }
        public List<object> Especialistas { get; set; }
    }
}
