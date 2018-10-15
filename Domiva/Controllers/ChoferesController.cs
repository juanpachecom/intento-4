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
    public class ChoferesController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: Choferes
        public ActionResult Index()
        {
            return View(db.Choferes.ToList());
        }

        // GET: Choferes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choferes choferes = db.Choferes.Find(id);
            if (choferes == null)
            {
                return HttpNotFound();
            }
            return View(choferes);
        }

        // GET: Choferes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Choferes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_chofer,Rut_chofer,Nombres_Chofer,Apellido_Chofer")] Choferes choferes)
        {
            if (ModelState.IsValid)
            {
                db.Choferes.Add(choferes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(choferes);
        }

        // GET: Choferes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choferes choferes = db.Choferes.Find(id);
            if (choferes == null)
            {
                return HttpNotFound();
            }
            return View(choferes);
        }

        // POST: Choferes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_chofer,Rut_chofer,Nombres_Chofer,Apellido_Chofer")] Choferes choferes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(choferes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(choferes);
        }

        // GET: Choferes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choferes choferes = db.Choferes.Find(id);
            if (choferes == null)
            {
                return HttpNotFound();
            }
            return View(choferes);
        }

        // POST: Choferes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Choferes choferes = db.Choferes.Find(id);
            db.Choferes.Remove(choferes);
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
