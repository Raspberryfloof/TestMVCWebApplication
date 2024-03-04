using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestMVCWebApplication;
using TestMVCWebApplication.Models;

namespace TestMVCWebApplication.Controllers
{
    public class StaffController : Controller
    {
        private TestMVC_DBEntities db = new TestMVC_DBEntities();

        // GET: Staff
        public ActionResult Index()
        {
            return View(db.StaffLists.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffList staffList = db.StaffLists.Find(id);
            if (staffList == null)
            {
                return HttpNotFound();
            }
            return View(staffList);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Pronouns,Department,Title,HireDate,IsActive")] StaffList staffList)
        {
            if (ModelState.IsValid)
            {
                db.StaffLists.Add(staffList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staffList);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffList staffList = db.StaffLists.Find(id);
            if (staffList == null)
            {
                return HttpNotFound();
            }
            return View(staffList);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Pronouns,Department,Title,HireDate,IsActive")] StaffList staffList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffList).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staffList);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffList staffList = db.StaffLists.Find(id);
            if (staffList == null)
            {
                return HttpNotFound();
            }
            return View(staffList);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            StaffList staffList = db.StaffLists.Find(id);
            db.StaffLists.Remove(staffList);
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
