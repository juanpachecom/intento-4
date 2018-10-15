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
    [Authorize(Roles = "Administrador,jefe_servicio,Secretaria")]
    public class Solicitud_estadoController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: Solicitud_estado
        public ActionResult Index()
        {
            return View(db.Solicitud_estado.ToList());
        }

        // GET: Solicitud_estado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_estado solicitud_estado = db.Solicitud_estado.Find(id);
            if (solicitud_estado == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_estado);
        }

        // GET: Solicitud_estado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Solicitud_estado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Id_solicitud,id_estado")] Solicitud_estado solicitud_estado)
        {
            if (ModelState.IsValid)
            {
                db.Solicitud_estado.Add(solicitud_estado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(solicitud_estado);
        }

        // GET: Solicitud_estado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_estado solicitud_estado = db.Solicitud_estado.Find(id);
            if (solicitud_estado == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_estado);
        }

        // POST: Solicitud_estado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Id_solicitud,id_estado")] Solicitud_estado solicitud_estado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud_estado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solicitud_estado);
        }

        // GET: Solicitud_estado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_estado solicitud_estado = db.Solicitud_estado.Find(id);
            if (solicitud_estado == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_estado);
        }

        // POST: Solicitud_estado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitud_estado solicitud_estado = db.Solicitud_estado.Find(id);
            db.Solicitud_estado.Remove(solicitud_estado);
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
