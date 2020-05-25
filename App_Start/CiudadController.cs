using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.App_Start
{
    public class CiudadController : Controller
    {
        // GET: Ciudad
        public ActionResult Index()
        {
            using (var db = new AlumnoContexto())
            {
                var al = db.Ciudad.ToList();
                return View(al);
            }
            
        }
    }
}