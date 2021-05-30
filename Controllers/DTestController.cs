using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestDateTime.Models;

namespace TestDateTime.Controllers
{
    public class DTestController : Controller
    {
        private MtRoomdbEntities db = new MtRoomdbEntities();

        // GET: DTest
        public ActionResult Index()
        {
            return View(db.DTests.ToList());
        }

        // GET: DTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTest dTest = db.DTests.Find(id);
            if (dTest == null)
            {
                return HttpNotFound();
            }
            return View(dTest);
        }

        // GET: DTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookid,startdate,remarks")] DTest dTest)
        {
            if (ModelState.IsValid)
            {
                db.DTests.Add(dTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dTest);
        }

        // GET: DTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTest dTest = db.DTests.Find(id);
            if (dTest == null)
            {
                return HttpNotFound();
            }
            return View(dTest);
        }

        // POST: DTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookid,startdate,remarks")] DTest dTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dTest);
        }

        // GET: DTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTest dTest = db.DTests.Find(id);
            if (dTest == null)
            {
                return HttpNotFound();
            }
            return View(dTest);
        }

        // POST: DTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DTest dTest = db.DTests.Find(id);
            db.DTests.Remove(dTest);
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
