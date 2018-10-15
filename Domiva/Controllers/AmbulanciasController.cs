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
    [Authorize(Roles = "Administrador")]
    public class AmbulanciasController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: Ambulancias
        public ActionResult Index()
        {
            var ambulancia = db.Ambulancia.Include(a => a.Ambulancia_tipo).Include(a => a.centro_asistencial);
            return View(ambulancia.ToList());
        }

        // GET: Ambulancias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambulancia ambulancia = db.Ambulancia.Find(id);
            if (ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(ambulancia);
        }

        // GET: Ambulancias/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo = new SelectList(db.Ambulancia_tipo, "Id_tipo", "Nombre");
            ViewBag.id_centro = new SelectList(db.centro_asistencial, "id_centro", "nombre_centro");
            return View();
        }

        // POST: Ambulancias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_ambulancia,id_tipo,patente,marca,modelo,año,numero_telefono,id_centro")] Ambulancia ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.Ambulancia.Add(ambulancia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipo = new SelectList(db.Ambulancia_tipo, "Id_tipo", "Nombre", ambulancia.id_tipo);
            ViewBag.id_centro = new SelectList(db.centro_asistencial, "id_centro", "nombre_centro", ambulancia.id_centro);
            return View(ambulancia);
        }

        // GET: Ambulancias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambulancia ambulancia = db.Ambulancia.Find(id);
            if (ambulancia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo = new SelectList(db.Ambulancia_tipo, "Id_tipo", "Nombre", ambulancia.id_tipo);
            ViewBag.id_centro = new SelectList(db.centro_asistencial, "id_centro", "nombre_centro", ambulancia.id_centro);
            return View(ambulancia);
        }

        // POST: Ambulancias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_ambulancia,id_tipo,patente,marca,modelo,año,numero_telefono,id_centro")] Ambulancia ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ambulancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo = new SelectList(db.Ambulancia_tipo, "Id_tipo", "Nombre", ambulancia.id_tipo);
            ViewBag.id_centro = new SelectList(db.centro_asistencial, "id_centro", "nombre_centro", ambulancia.id_centro);
            return View(ambulancia);
        }

        // GET: Ambulancias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambulancia ambulancia = db.Ambulancia.Find(id);
            if (ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(ambulancia);
        }

        // POST: Ambulancias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ambulancia ambulancia = db.Ambulancia.Find(id);
            db.Ambulancia.Remove(ambulancia);
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
