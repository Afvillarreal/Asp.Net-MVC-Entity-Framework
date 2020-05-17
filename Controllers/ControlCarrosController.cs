using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class ControlCarrosController : Controller
    {
        // GET: ControlCarros
        public ActionResult IndexCarros()
        {
            AlumnosContext db = new AlumnosContext();

            List<Alumno> lista = db.Alumno.ToList();

            return View(lista);
        }
        
    }
}