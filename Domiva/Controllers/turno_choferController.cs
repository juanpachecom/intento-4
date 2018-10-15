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
    public class turno_choferController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: turno_chofer
        public ActionResult Index()
        {
            var turno_chofer = db.turno_chofer.Include(t => t.Choferes).Include(t => t.turno);
            return View(turno_chofer.ToList());
        }

        // GET: turno_chofer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            turno_chofer turno_chofer = db.turno_chofer.Find(id);
            if (turno_chofer == null)
            {
                return HttpNotFound();
            }
            return View(turno_chofer);
        }

        // GET: turno_chofer/Create
        public ActionResult Create()
        {
            ViewBag.id_chofer = new SelectList(db.Choferes, "Id_chofer", "Rut_chofer");
            ViewBag.id_turno = new SelectList(db.turno, "id_turno", "nombre_turno");
            return View();
        }

        // POST: turno_chofer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_turno_chofer,id_turno,id_chofer,fecha")] turno_chofer turno_chofer)
        {
            if (ModelState.IsValid)
            {
                db.turno_chofer.Add(turno_chofer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_chofer = new SelectList(db.Choferes, "Id_chofer", "Rut_chofer", turno_chofer.id_chofer);
            ViewBag.id_turno = new SelectList(db.turno, "id_turno", "nombre_turno", turno_chofer.id_turno);
            return View(turno_chofer);
        }

        // GET: turno_chofer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            turno_chofer turno_chofer = db.turno_chofer.Find(id);
            if (turno_chofer == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_chofer = new SelectList(db.Choferes, "Id_chofer", "Rut_chofer", turno_chofer.id_chofer);
            ViewBag.id_turno = new SelectList(db.turno, "id_turno", "nombre_turno", turno_chofer.id_turno);
            return View(turno_chofer);
        }

        // POST: turno_chofer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_turno_chofer,id_turno,id_chofer,fecha")] turno_chofer turno_chofer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turno_chofer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_chofer = new SelectList(db.Choferes, "Id_chofer", "Rut_chofer", turno_chofer.id_chofer);
            ViewBag.id_turno = new SelectList(db.turno, "id_turno", "nombre_turno", turno_chofer.id_turno);
            return View(turno_chofer);
        }

        // GET: turno_chofer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            turno_chofer turno_chofer = db.turno_chofer.Find(id);
            if (turno_chofer == null)
            {
                return HttpNotFound();
            }
            return View(turno_chofer);
        }

        // POST: turno_chofer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            turno_chofer turno_chofer = db.turno_chofer.Find(id);
            db.turno_chofer.Remove(turno_chofer);
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
