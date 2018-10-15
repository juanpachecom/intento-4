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
    public class personal_correoController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: personal_correo
        public ActionResult Index()
        {
            var personal_correo = db.personal_correo.Include(p => p.AspNetUsers).Include(p => p.Personal);
            return View(personal_correo.ToList());
        }

        // GET: personal_correo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal_correo personal_correo = db.personal_correo.Find(id);
            if (personal_correo == null)
            {
                return HttpNotFound();
            }
            return View(personal_correo);
        }

        // GET: personal_correo/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal");
            return View();
        }

        // POST: personal_correo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_p_co,id_personal,id")] personal_correo personal_correo)
        {
            if (ModelState.IsValid)
            {
                db.personal_correo.Add(personal_correo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.AspNetUsers, "Id", "Email", personal_correo.id);
            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal", personal_correo.id_personal);
            return View(personal_correo);
        }

        // GET: personal_correo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal_correo personal_correo = db.personal_correo.Find(id);
            if (personal_correo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.AspNetUsers, "Id", "Email", personal_correo.id);
            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal", personal_correo.id_personal);
            return View(personal_correo);
        }

        // POST: personal_correo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_p_co,id_personal,id")] personal_correo personal_correo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal_correo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.AspNetUsers, "Id", "Email", personal_correo.id);
            ViewBag.id_personal = new SelectList(db.Personal, "Id_personal", "Rut_personal", personal_correo.id_personal);
            return View(personal_correo);
        }

        // GET: personal_correo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personal_correo personal_correo = db.personal_correo.Find(id);
            if (personal_correo == null)
            {
                return HttpNotFound();
            }
            return View(personal_correo);
        }

        // POST: personal_correo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personal_correo personal_correo = db.personal_correo.Find(id);
            db.personal_correo.Remove(personal_correo);
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
