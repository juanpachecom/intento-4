using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domiva.Models;

namespace Domiva.Controllers
{
    [Authorize(Roles = "Administrador,jefe_servicio,secretaria")]
    public class Solicitud_ambulanciaController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: Solicitud_ambulancia
        public ActionResult Index()
        {
            var solicitud_ambulancia = db.Solicitud_ambulancia.Include(s => s.Ambulancia).Include(s => s.Solicitudes);
            return View(solicitud_ambulancia.ToList());
        }

        // GET: Solicitud_ambulancia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_ambulancia solicitud_ambulancia = db.Solicitud_ambulancia.Find(id);
            if (solicitud_ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_ambulancia);
        }

        // GET: Solicitud_ambulancia/Create
        public ActionResult Create()
        {
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente");
            ViewBag.id_solicitud = new SelectList(db.Solicitudes, "id_solicitud", "Coordenada");
            return View();
        }

        // POST: Solicitud_ambulancia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_asistencia,id_solicitud,id_ambulancia")] Solicitud_ambulancia solicitud_ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.Solicitud_ambulancia.Add(solicitud_ambulancia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", solicitud_ambulancia.id_ambulancia);
            ViewBag.id_solicitud = new SelectList(db.Solicitudes, "id_solicitud", "Coordenada", solicitud_ambulancia.id_solicitud);
            return View(solicitud_ambulancia);
        }

        // GET: Solicitud_ambulancia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_ambulancia solicitud_ambulancia = db.Solicitud_ambulancia.Find(id);
            if (solicitud_ambulancia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", solicitud_ambulancia.id_ambulancia);
            ViewBag.id_solicitud = new SelectList(db.Solicitudes, "id_solicitud", "Coordenada", solicitud_ambulancia.id_solicitud);
            return View(solicitud_ambulancia);
        }

        // POST: Solicitud_ambulancia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_asistencia,id_solicitud,id_ambulancia")] Solicitud_ambulancia solicitud_ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud_ambulancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", solicitud_ambulancia.id_ambulancia);
            ViewBag.id_solicitud = new SelectList(db.Solicitudes, "id_solicitud", "Coordenada", solicitud_ambulancia.id_solicitud);
            return View(solicitud_ambulancia);
        }

        // GET: Solicitud_ambulancia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_ambulancia solicitud_ambulancia = db.Solicitud_ambulancia.Find(id);
            if (solicitud_ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_ambulancia);
        }

        // POST: Solicitud_ambulancia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitud_ambulancia solicitud_ambulancia = db.Solicitud_ambulancia.Find(id);
            db.Solicitud_ambulancia.Remove(solicitud_ambulancia);
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
