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
                 //AlumnosContext db = new AlumnosContext(); // AlumnoContext fue el nombre de la db al momento de crearla en la parte de elegir conexion a datos parte inferior.           
                //List<Alumno> lista = db.Alumno.Where(a => a.Edad > 18).ToList();

                try
                {
                    using (var db = new AlumnosContext())
                    {

                    //List<Alumno> lista = db.Alumno.Where(a => a.Edad > 18).ToList();
                    //return (lista);

                    return View(db.Alumno.ToList());
                    }
                }
                catch (Exception)
                {
                    throw;
                }

        }


        [HttpGet]//si no se conoca nada se sobre entiende que es este metodo
         
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost] //este si hay que colocarlo 
        [ValidateAntiForgeryToken] // this check if the formulary which is being sending
        public ActionResult Agregar(Alumno a)
        {
            if (!ModelState.IsValid)    //@Html.ValidationSummary(true, "", new { @class = "text-danger" }) here return this line in view
                return View();          //in other words it show somting like "el campo ingrese el nombre es requerido" if case of a person doesn't fill in the space
            try
            {
                using (var db = new AlumnosContext())//this is the same that above but this is better this using open and close the database in order to use less resources
                {                                               //when this using ends, the connection to the data also ends
                    a.Fecha_Registro = DateTime.Now;
                    db.Alumno.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Error al agregar el argumento"+ ex.Message);
                return View();
            }
                                      
        }

    }
}