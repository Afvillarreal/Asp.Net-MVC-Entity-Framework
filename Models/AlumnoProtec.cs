using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Alumnos.Models
{
    //this class is created in order to protect the model of alumno as everytime we change the model or update, the model will reboot to the origin.

    public class AlumnoProtec
    {
        [Required]
        [Display (Name ="Ingrese Nombre")]
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

        [Required]
        [Display(Name = "Ciudad")]
        public int CodCiudad { get; set; }

    }

    //[MetadataType(typeof(AlumnoProtec))]
    public partial class Alumno {
       
        public String NombreCompleto {get {return Nombres + " " + Apellidos; } }
     }

}