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
        public ActionResult IndexdeAlumno()
        {
            try
            {
                using (var db = new AlumnoContexto())
                {
                    return View(db.Alumno.ToList());
                }

            }
            catch (Exception )
            {

                throw;
            }            
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]//this is necesary cause the program wont know which "Agregar" use HttpPost is for set and HttpGet if for get
        [ValidateAntiForgeryToken]//this is for validate the if the format is correct
        public ActionResult Agregar(Alumno a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new AlumnoContexto())
                {
                    a.Fecha_Registro = DateTime.Now;

                    db.Alumno.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("IndexdeAlumno");
                }
                
            }
            catch (Exception e)
            {              
                ModelState.AddModelError("","Error al Crear Alumno"+ e.Message);
                return View();
            }
           
        }

        public ActionResult ListaCiudades()
        {
            using(var db = new AlumnoContexto())
            {
                return PartialView(db.Alumno.ToString());
            }
        }

        
        [HttpGet]
        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new AlumnoContexto())
                {

                    //Alumno al = db.Alumno.Where(a => a.id == id).FirstOrDefault();//chosse the first which has that condicion and if not exist return a null, Where can be used in what ever case
                    Alumno al2 = db.Alumno.Find(id);//this do the same but ONLY USE WHEN I KNOW THAT EXIST UNIQUE PRIMARY KEY
                    return View(al2);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Alumno a)
        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                using(var db = new AlumnoContexto())
                {
                    var al = db.Alumno.Find(a.id);
                    al.Nombres = a.Nombres;
                    al.Apellidos = a.Apellidos;
                    al.Edad = a.Edad;
                    al.Sexo = a.Sexo;
                    db.SaveChanges();

                    return RedirectToAction("IndexdeAlumno");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public ActionResult DetallesUsuario(int id)
        {
            using(var db = new AlumnoContexto())
            {
                var al = db.Alumno.Find(id);
                return View(al);
            }
            
        }

        public ActionResult EliminarUsuario(int id)
        {
            using (var db = new AlumnoContexto() )
            {
                Alumno al = db.Alumno.Find(id);
                db.Alumno.Remove(al);
                db.SaveChanges();
                return RedirectToAction("IndexdeAlumno");
            }
        }

    }
}