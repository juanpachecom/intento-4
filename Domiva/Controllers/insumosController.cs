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
    public class insumosController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: insumos
        public ActionResult Index()
        {
            return View(db.insumos.ToList());
        }

        // GET: insumos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insumos insumos = db.insumos.Find(id);
            if (insumos == null)
            {
                return HttpNotFound();
            }
            return View(insumos);
        }

        // GET: insumos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: insumos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_insumos,codigo,nombre,descripcion")] insumos insumos)
        {
            if (ModelState.IsValid)
            {
                db.insumos.Add(insumos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insumos);
        }

        // GET: insumos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insumos insumos = db.insumos.Find(id);
            if (insumos == null)
            {
                return HttpNotFound();
            }
            return View(insumos);
        }

        // POST: insumos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_insumos,codigo,nombre,descripcion")] insumos insumos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insumos);
        }

        // GET: insumos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insumos insumos = db.insumos.Find(id);
            if (insumos == null)
            {
                return HttpNotFound();
            }
            return View(insumos);
        }

        // POST: insumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            insumos insumos = db.insumos.Find(id);
            db.insumos.Remove(insumos);
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
