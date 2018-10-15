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
    public class ambulancia_estadoController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: ambulancia_estado
        public ActionResult Index()
        {
            var ambulancia_estado = db.ambulancia_estado.Include(a => a.Ambulancia).Include(a => a.estado_ambulancia);
            return View(ambulancia_estado.ToList());
        }

        // GET: ambulancia_estado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ambulancia_estado ambulancia_estado = db.ambulancia_estado.Find(id);
            if (ambulancia_estado == null)
            {
                return HttpNotFound();
            }
            return View(ambulancia_estado);
        }

        // GET: ambulancia_estado/Create
        public ActionResult Create()
        {
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente");
            ViewBag.id_estado = new SelectList(db.estado_ambulancia, "id_estado", "Descripsion");
            return View();
        }

        // POST: ambulancia_estado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estadoambulancia,id_ambulancia,id_estado")] ambulancia_estado ambulancia_estado)
        {
            if (ModelState.IsValid)
            {
                db.ambulancia_estado.Add(ambulancia_estado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", ambulancia_estado.id_ambulancia);
            ViewBag.id_estado = new SelectList(db.estado_ambulancia, "id_estado", "Descripsion", ambulancia_estado.id_estado);
            return View(ambulancia_estado);
        }

        // GET: ambulancia_estado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ambulancia_estado ambulancia_estado = db.ambulancia_estado.Find(id);
            if (ambulancia_estado == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", ambulancia_estado.id_ambulancia);
            ViewBag.id_estado = new SelectList(db.estado_ambulancia, "id_estado", "Descripsion", ambulancia_estado.id_estado);
            return View(ambulancia_estado);
        }

        // POST: ambulancia_estado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estadoambulancia,id_ambulancia,id_estado")] ambulancia_estado ambulancia_estado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ambulancia_estado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", ambulancia_estado.id_ambulancia);
            ViewBag.id_estado = new SelectList(db.estado_ambulancia, "id_estado", "Descripsion", ambulancia_estado.id_estado);
            return View(ambulancia_estado);
        }

        // GET: ambulancia_estado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ambulancia_estado ambulancia_estado = db.ambulancia_estado.Find(id);
            if (ambulancia_estado == null)
            {
                return HttpNotFound();
            }
            return View(ambulancia_estado);
        }

        // POST: ambulancia_estado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ambulancia_estado ambulancia_estado = db.ambulancia_estado.Find(id);
            db.ambulancia_estado.Remove(ambulancia_estado);
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
