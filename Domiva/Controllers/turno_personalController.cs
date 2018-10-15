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
    [Authorize(Roles = "Administrador,jefe_servicio")]
    public class turno_personalController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: turno_personal
        public ActionResult Index()
        {
            var turno_personal = db.turno_personal.Include(t => t.Personal).Include(t => t.turno);
            return View(turno_personal.ToList());
        }

        // GET: turno_personal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            turno_personal turno_personal = db.turno_personal.Find(id);
            if (turno_personal == null)
            {
                return HttpNotFound();
            }
            return View(turno_personal);
        }

        // GET: turno_personal/Create
        public ActionResult Create()
        {
            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal");
            ViewBag.id_turno = new SelectList(db.turno, "id_turno", "nombre_turno");
            return View();
        }

        // POST: turno_personal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_turno_personal,id_turno,id_personal,fecha")] turno_personal turno_personal)
        {
            if (ModelState.IsValid)
            {
                db.turno_personal.Add(turno_personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal", turno_personal.id_personal);
            ViewBag.id_turno = new SelectList(db.turno, "id_turno", "nombre_turno", turno_personal.id_turno);
            return View(turno_personal);
        }

        // GET: turno_personal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            turno_personal turno_personal = db.turno_personal.Find(id);
            if (turno_personal == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal", turno_personal.id_personal);
            ViewBag.id_turno = new SelectList(db.turno, "id_turno", "nombre_turno", turno_personal.id_turno);
            return View(turno_personal);
        }

        // POST: turno_personal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_turno_personal,id_turno,id_personal,fecha")] turno_personal turno_personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turno_personal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal", turno_personal.id_personal);
            ViewBag.id_turno = new SelectList(db.turno, "id_turno", "nombre_turno", turno_personal.id_turno);
            return View(turno_personal);
        }

        // GET: turno_personal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            turno_personal turno_personal = db.turno_personal.Find(id);
            if (turno_personal == null)
            {
                return HttpNotFound();
            }
            return View(turno_personal);
        }

        // POST: turno_personal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            turno_personal turno_personal = db.turno_personal.Find(id);
            db.turno_personal.Remove(turno_personal);
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
