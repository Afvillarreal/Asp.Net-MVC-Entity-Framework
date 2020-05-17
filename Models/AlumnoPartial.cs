using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Alumnos.Models
{
    public class AlumnoPartial
    {

        [Required]                            //it means that this space is obligatory
        [Display(Name = "Ingrese nombres")]   //this means that if the space is not completed it's gonna show this message
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Ingrese Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Ingrese Edad")]
        public int Edad { get; set; }

        [Required]
        [Display(Name = "Ingrese Sexo")]
        public string Sexo { get; set; }
    }

    [MetadataType(typeof(AlumnoPartial))]

    public partial class Alumno
    {
        public String NombreCompleto { get { return Nombres + " " + Apellidos; } }
        public int suma { get { return Edad + 10; } }
    }
}