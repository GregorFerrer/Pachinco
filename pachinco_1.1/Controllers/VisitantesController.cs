using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary1;

namespace pachinco_1._1.Controllers
{
    public class VisitantesController : Controller
    {
        private Entities db = new Entities();

        // GET: Visitantes
        public ActionResult Index()
        {
            return View(db.Visitante.ToList());
        }

        // GET: Visitantes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitante visitante = db.Visitante.Find(id);
            if (visitante == null)
            {
                return HttpNotFound();
            }
            return View(visitante);
        }

        // GET: Visitantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visitantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numero_identificacion,nombres,apellidos,conteo_visitante,edad,sexo")] Visitante visitante)
        {
            if (ModelState.IsValid)
            {
                db.Visitante.Add(visitante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visitante);
        }

        // GET: Visitantes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitante visitante = db.Visitante.Find(id);
            if (visitante == null)
            {
                return HttpNotFound();
            }
            return View(visitante);
        }

        // POST: Visitantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numero_identificacion,nombres,apellidos,conteo_visitante,edad,sexo")] Visitante visitante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visitante);
        }

        // GET: Visitantes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitante visitante = db.Visitante.Find(id);
            if (visitante == null)
            {
                return HttpNotFound();
            }
            return View(visitante);
        }

        // POST: Visitantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Visitante visitante = db.Visitante.Find(id);
            db.Visitante.Remove(visitante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
