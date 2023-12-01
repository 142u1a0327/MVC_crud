using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CRud.DataConnection;
using MVC_CRud.Models;

namespace MVC_CRud.Controllers
{
    public class EmployeeesController : Controller
    {
        private DB_context db = new DB_context();

        // GET: Employeees
        public ActionResult Index()
        {
            return View(db.Employee_table.ToList());
        }

        // GET: Employeees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = db.Employee_table.Find(id);
            if (employeee == null)
            {
                return HttpNotFound();
            }
            return View(employeee);
        }

        // GET: Employeees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employeees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Firstname,Lastname,Age,Gender")] Employeee employeee)
        {
            if (ModelState.IsValid)
            {
                db.Employee_table.Add(employeee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeee);
        }

        // GET: Employeees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = db.Employee_table.Find(id);
            if (employeee == null)
            {
                return HttpNotFound();
            }
            return View(employeee);
        }

        // POST: Employeees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Firstname,Lastname,Age,Gender")] Employeee employeee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeee);
        }

        // GET: Employeees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = db.Employee_table.Find(id);
            if (employeee == null)
            {
                return HttpNotFound();
            }
            return View(employeee);
        }

        // POST: Employeees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employeee employeee = db.Employee_table.Find(id);
            db.Employee_table.Remove(employeee);
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
