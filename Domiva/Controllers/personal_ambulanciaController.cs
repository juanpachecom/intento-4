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
    public class personal_ambulanciaController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: personal_ambulancia
        public ActionResult Index()
        {
            var personal_ambulancia = db.personal_ambulancia.Include(p => p.Ambulancia).Include(p => p.Personal);
            return View(personal_ambulancia.ToList());
        }

        // GET: personal_ambulancia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal_ambulancia personal_ambulancia = db.personal_ambulancia.Find(id);
            if (personal_ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(personal_ambulancia);
        }

        // GET: personal_ambulancia/Create
        public ActionResult Create()
        {
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente");
            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal");
            return View();
        }

        // POST: personal_ambulancia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_p_a,id_ambulancia,id_personal")] personal_ambulancia personal_ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.personal_ambulancia.Add(personal_ambulancia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", personal_ambulancia.id_ambulancia);
            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal", personal_ambulancia.id_personal);
            return View(personal_ambulancia);
        }

        // GET: personal_ambulancia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal_ambulancia personal_ambulancia = db.personal_ambulancia.Find(id);
            if (personal_ambulancia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", personal_ambulancia.id_ambulancia);
            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal", personal_ambulancia.id_personal);
            return View(personal_ambulancia);
        }

        // POST: personal_ambulancia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_p_a,id_ambulancia,id_personal")] personal_ambulancia personal_ambulancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal_ambulancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_ambulancia = new SelectList(db.Ambulancia, "Id_ambulancia", "patente", personal_ambulancia.id_ambulancia);
            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal", personal_ambulancia.id_personal);
            return View(personal_ambulancia);
        }

        // GET: personal_ambulancia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal_ambulancia personal_ambulancia = db.personal_ambulancia.Find(id);
            if (personal_ambulancia == null)
            {
                return HttpNotFound();
            }
            return View(personal_ambulancia);
        }

        // POST: personal_ambulancia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personal_ambulancia personal_ambulancia = db.personal_ambulancia.Find(id);
            db.personal_ambulancia.Remove(personal_ambulancia);
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
