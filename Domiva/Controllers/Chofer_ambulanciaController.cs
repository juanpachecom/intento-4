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
    public class Chofer_ambulanciaController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: Chofer_ambulancia
        public ActionResult Index()
        {
            var chofer_ambulancia = db.Chofer_ambulancia.Include(c => c.Ambulancia).Include(c => c.Choferes);
            return View(chofer_ambulancia.ToList());
        }

        // GET: Chofer_ambulancia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chofer_ambulancia chofer_ambulancia = db.Chofer_ambulancia.Find(id);
            if (chofer_ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(chofer_ambulancia);
        }

        // GET: Chofer_ambulancia/Create
        public ActionResult Create()
        {
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente");
            ViewBag.id_chofer = new SelectList(db.Choferes, "Id_chofer", "Rut_chofer");
            return View();
        }

        // POST: Chofer_ambulancia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_chofe_amb,id_chofer,id_ambulancia")] Chofer_ambulancia chofer_ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.Chofer_ambulancia.Add(chofer_ambulancia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", chofer_ambulancia.id_ambulancia);
            ViewBag.id_chofer = new SelectList(db.Choferes, "Id_chofer", "Rut_chofer", chofer_ambulancia.id_chofer);
            return View(chofer_ambulancia);
        }

        // GET: Chofer_ambulancia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chofer_ambulancia chofer_ambulancia = db.Chofer_ambulancia.Find(id);
            if (chofer_ambulancia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", chofer_ambulancia.id_ambulancia);
            ViewBag.id_chofer = new SelectList(db.Choferes, "Id_chofer", "Rut_chofer", chofer_ambulancia.id_chofer);
            return View(chofer_ambulancia);
        }

        // POST: Chofer_ambulancia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_chofe_amb,id_chofer,id_ambulancia")] Chofer_ambulancia chofer_ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chofer_ambulancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", chofer_ambulancia.id_ambulancia);
            ViewBag.id_chofer = new SelectList(db.Choferes, "Id_chofer", "Rut_chofer", chofer_ambulancia.id_chofer);
            return View(chofer_ambulancia);
        }

        // GET: Chofer_ambulancia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chofer_ambulancia chofer_ambulancia = db.Chofer_ambulancia.Find(id);
            if (chofer_ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(chofer_ambulancia);
        }

        // POST: Chofer_ambulancia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chofer_ambulancia chofer_ambulancia = db.Chofer_ambulancia.Find(id);
            db.Chofer_ambulancia.Remove(chofer_ambulancia);
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
