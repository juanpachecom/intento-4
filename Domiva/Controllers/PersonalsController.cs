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
    public class PersonalsController : Controller
    {
        private DomivaEntities db = new DomivaEntities();

        // GET: Personals
        public ActionResult Index()
        {
            var personal = db.Personal.Include(p => p.afp1).Include(p => p.AspNetRoles).Include(p => p.centro_asistencial).Include(p => p.salud1);
            return View(personal.ToList());
        }

        // GET: Personals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // GET: Personals/Create
        public ActionResult Create()
        {
            ViewBag.afp = new SelectList(db.afp, "id_afp", "nombre_afp");
            ViewBag.id_rol = new SelectList(db.AspNetRoles, "Id", "Name");
            ViewBag.id_centro = new SelectList(db.centro_asistencial, "id_centro", "nombre_centro");
            ViewBag.salud = new SelectList(db.salud, "id_salud", "id_nombre");
            return View();
        }

        // POST: Personals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_personal,Rut_personal,Nombre_personal,Apellido_perso,numero_telefonico,direccion,afp,salud,id_rol,id_centro")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Personal.Add(personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.afp = new SelectList(db.afp, "id_afp", "nombre_afp", personal.afp);
            ViewBag.id_rol = new SelectList(db.AspNetRoles, "Id", "Name", personal.id_rol);
            ViewBag.id_centro = new SelectList(db.centro_asistencial, "id_centro", "nombre_centro", personal.id_centro);
            ViewBag.salud = new SelectList(db.salud, "id_salud", "id_nombre", personal.salud);
            return View(personal);
        }

        // GET: Personals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            ViewBag.afp = new SelectList(db.afp, "id_afp", "nombre_afp", personal.afp);
            ViewBag.id_rol = new SelectList(db.AspNetRoles, "Id", "Name", personal.id_rol);
            ViewBag.id_centro = new SelectList(db.centro_asistencial, "id_centro", "nombre_centro", personal.id_centro);
            ViewBag.salud = new SelectList(db.salud, "id_salud", "id_nombre", personal.salud);
            return View(personal);
        }

        // POST: Personals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_personal,Rut_personal,Nombre_personal,Apellido_perso,numero_telefonico,direccion,afp,salud,id_rol,id_centro")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.afp = new SelectList(db.afp, "id_afp", "nombre_afp", personal.afp);
            ViewBag.id_rol = new SelectList(db.AspNetRoles, "Id", "Name", personal.id_rol);
            ViewBag.id_centro = new SelectList(db.centro_asistencial, "id_centro", "nombre_centro", personal.id_centro);
            ViewBag.salud = new SelectList(db.salud, "id_salud", "id_nombre", personal.salud);
            return View(personal);
        }

        // GET: Personals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = db.Personal.Find(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: Personals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personal personal = db.Personal.Find(id);
            db.Personal.Remove(personal);
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
