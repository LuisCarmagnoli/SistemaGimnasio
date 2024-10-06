using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaGimnasio.Model
{
    public class ClaseModel
    {
        //Fields
        private int idClase;
        private string nombreClase;
        private string instructor;
        private string horario;
        private int capacidad;
        private int espaciosDisponibles;

        //Properties - Validations
        [DisplayName("Id Clase")]
        public int IdClase { get => idClase; set => idClase = value; }

        [DisplayName("Nombre Clase")]
        [Required(ErrorMessage = "El nombre de la clase es requerido")]
        [StringLength(50,MinimumLength=3, ErrorMessage = "El nombre de la clase debe tener entre 3 y 50 caracteres")]
        public string NombreClase { get => nombreClase; set => nombreClase = value; }

        [DisplayName("Nombre Instructor")]
        [Required(ErrorMessage = "El nombre del instructor es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del instructor debe tener entre 3 y 50 caracteres")]
        public string Instructor { get => instructor; set => instructor = value; }

        [DisplayName("Horario Clase")]
        [Required(ErrorMessage = "El horario es requerido")]
        public string Horario { get => horario; set => horario = value; }

        [DisplayName("Capacidad maxima")]
        [Required(ErrorMessage = "La capacidad es requerida")]
        public int Capacidad { get => capacidad; set => capacidad = value; }

        [DisplayName("Espacios disponibles")]
        [Required(ErrorMessage = "El espacio disponible es requerido")]
        public int EspaciosDisponibles { get => espaciosDisponibles; set => espaciosDisponibles = value; }
    }
}
