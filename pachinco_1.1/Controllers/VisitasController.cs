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
    public class VisitasController : Controller
    {


        private Entities db = new Entities();

        // GET: Visitas
        public ActionResult Index()
        {
            var visita = db.Visita.Include(v => v.Guia).Include(v => v.Visitante);
            return View(visita.ToList());
        }


        // GET: Visitas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: Visitas/Create
        public ActionResult Create()
        {
            ViewBag.id_guia = new SelectList(db.Guia, "id_guia", "nombre_guia");
            ViewBag.numero_identificacion = new SelectList(db.Visitante, "numero_identificacion", "nombres");
            return View();
        }

        // POST: Visitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_visita,fecha_visita,hora_visita,id_guia,numero_identificacion")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Visita.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_guia = new SelectList(db.Guia, "id_guia", "nombre_guia", visita.id_guia);
            ViewBag.numero_identificacion = new SelectList(db.Visitante, "numero_identificacion", "nombres", visita.numero_identificacion);
            return View(visita);
        }

        // GET: Visitas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_guia = new SelectList(db.Guia, "id_guia", "nombre_guia", visita.id_guia);
            ViewBag.numero_identificacion = new SelectList(db.Visitante, "numero_identificacion", "nombres", visita.numero_identificacion);
            return View(visita);
        }

        // POST: Visitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_visita,fecha_visita,hora_visita,id_guia,numero_identificacion")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_guia = new SelectList(db.Guia, "id_guia", "nombre_guia", visita.id_guia);
            ViewBag.numero_identificacion = new SelectList(db.Visitante, "numero_identificacion", "nombres", visita.numero_identificacion);
            return View(visita);
        }

        // GET: Visitas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Visita visita = db.Visita.Find(id);
            db.Visita.Remove(visita);
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
