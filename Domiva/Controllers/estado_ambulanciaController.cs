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
    public class estado_ambulanciaController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: estado_ambulancia
        public ActionResult Index()
        {
            return View(db.estado_ambulancia.ToList());
        }

        // GET: estado_ambulancia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_ambulancia estado_ambulancia = db.estado_ambulancia.Find(id);
            if (estado_ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(estado_ambulancia);
        }

        // GET: estado_ambulancia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estado_ambulancia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estado,Descripsion")] estado_ambulancia estado_ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.estado_ambulancia.Add(estado_ambulancia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_ambulancia);
        }

        // GET: estado_ambulancia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_ambulancia estado_ambulancia = db.estado_ambulancia.Find(id);
            if (estado_ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(estado_ambulancia);
        }

        // POST: estado_ambulancia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estado,Descripsion")] estado_ambulancia estado_ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_ambulancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_ambulancia);
        }

        // GET: estado_ambulancia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estado_ambulancia estado_ambulancia = db.estado_ambulancia.Find(id);
            if (estado_ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(estado_ambulancia);
        }

        // POST: estado_ambulancia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estado_ambulancia estado_ambulancia = db.estado_ambulancia.Find(id);
            db.estado_ambulancia.Remove(estado_ambulancia);
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
