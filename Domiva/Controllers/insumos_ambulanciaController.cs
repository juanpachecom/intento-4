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
    public class insumos_ambulanciaController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: insumos_ambulancia
        public ActionResult Index()
        {
            var insumos_ambulancia = db.insumos_ambulancia.Include(i => i.Ambulancia).Include(i => i.insumos);
            return View(insumos_ambulancia.ToList());
        }

        // GET: insumos_ambulancia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insumos_ambulancia insumos_ambulancia = db.insumos_ambulancia.Find(id);
            if (insumos_ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(insumos_ambulancia);
        }

        // GET: insumos_ambulancia/Create
        public ActionResult Create()
        {
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente");
            ViewBag.id_insumos = new SelectList(db.insumos, "Id_insumos", "codigo");
            return View();
        }

        // POST: insumos_ambulancia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_insumo_ambulancia,id_insumos,id_ambulancia,fecha")] insumos_ambulancia insumos_ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.insumos_ambulancia.Add(insumos_ambulancia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", insumos_ambulancia.id_ambulancia);
            ViewBag.id_insumos = new SelectList(db.insumos, "Id_insumos", "codigo", insumos_ambulancia.id_insumos);
            return View(insumos_ambulancia);
        }

        // GET: insumos_ambulancia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insumos_ambulancia insumos_ambulancia = db.insumos_ambulancia.Find(id);
            if (insumos_ambulancia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", insumos_ambulancia.id_ambulancia);
            ViewBag.id_insumos = new SelectList(db.insumos, "Id_insumos", "codigo", insumos_ambulancia.id_insumos);
            return View(insumos_ambulancia);
        }

        // POST: insumos_ambulancia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_insumo_ambulancia,id_insumos,id_ambulancia,fecha")] insumos_ambulancia insumos_ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumos_ambulancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", insumos_ambulancia.id_ambulancia);
            ViewBag.id_insumos = new SelectList(db.insumos, "Id_insumos", "codigo", insumos_ambulancia.id_insumos);
            return View(insumos_ambulancia);
        }

        // GET: insumos_ambulancia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insumos_ambulancia insumos_ambulancia = db.insumos_ambulancia.Find(id);
            if (insumos_ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(insumos_ambulancia);
        }

        // POST: insumos_ambulancia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            insumos_ambulancia insumos_ambulancia = db.insumos_ambulancia.Find(id);
            db.insumos_ambulancia.Remove(insumos_ambulancia);
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
