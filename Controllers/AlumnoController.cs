using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            AlumnosContext db = new AlumnosContext(); // AlumnoContext fue el nombre de la db al momento de crearla en la parte de elegir conexion a datos parte inferior.


            //List<Alumno> lista = db.Alumno.Where(a => a.Edad > 18).ToList();

            return View(db.Alumno.ToList());
        }

        [HttpGet]//si no se conoca nada se sobre entiende que es este metodo
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost] //este si hay que colocarlo 
        public ActionResult Agregar(Alumno a)
        {
            return View();
        }

    }
}