﻿using System;
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
    public class StudentDetailsController : Controller
    {
        private DB_context db = new DB_context();

        // GET: StudentDetails
        public ActionResult Index()
        {
            return View(db.StudentDetails.ToList());
        }

        // GET: StudentDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDetails studentDetails = db.StudentDetails.Find(id);
            if (studentDetails == null)
            {
                return HttpNotFound();
            }
            return View(studentDetails);
        }

        // GET: StudentDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StuID,Studentname,Fathername,Mothername")] StudentDetails studentDetails)
        {
            if (ModelState.IsValid)
            {
                db.StudentDetails.Add(studentDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentDetails);
        }

        // GET: StudentDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDetails studentDetails = db.StudentDetails.Find(id);
            if (studentDetails == null)
            {
                return HttpNotFound();
            }
            return View(studentDetails);
        }

        // POST: StudentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StuID,Studentname,Fathername,Mothername")] StudentDetails studentDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentDetails);
        }

        // GET: StudentDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDetails studentDetails = db.StudentDetails.Find(id);
            if (studentDetails == null)
            {
                return HttpNotFound();
            }
            return View(studentDetails);
        }

        // POST: StudentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentDetails studentDetails = db.StudentDetails.Find(id);
            db.StudentDetails.Remove(studentDetails);
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
