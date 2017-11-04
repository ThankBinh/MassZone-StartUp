using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MassZone_API.Models;

namespace MassZone_API.Controllers
{
    public class CheckOutController : Controller
    {
        private DataContext db = new DataContext();

        // GET: CheckOut
        public ActionResult Index()
        {
            var checkOuts = db.CheckOuts.Include(c => c.Products).Include(c => c.Users);
            return View(checkOuts.ToList());
        }

        // GET: CheckOut/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut checkOut = db.CheckOuts.Find(id);
            if (checkOut == null)
            {
                return HttpNotFound();
            }
            return View(checkOut);
        }

        // GET: CheckOut/Create
        public ActionResult Create()
        {
            ViewBag.proId = new SelectList(db.Products, "proId", "proName");
            ViewBag.userId = new SelectList(db.Users, "userId", "userName");
            return View();
        }

        // POST: CheckOut/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ckId,quantity,ckTime,status,userId,proId")] CheckOut checkOut)
        {
            if (ModelState.IsValid)
            {
                db.CheckOuts.Add(checkOut);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proId = new SelectList(db.Products, "proId", "proName", checkOut.proId);
            ViewBag.userId = new SelectList(db.Users, "userId", "userName", checkOut.userId);
            return View(checkOut);
        }

        // GET: CheckOut/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut checkOut = db.CheckOuts.Find(id);
            if (checkOut == null)
            {
                return HttpNotFound();
            }
            ViewBag.proId = new SelectList(db.Products, "proId", "proName", checkOut.proId);
            ViewBag.userId = new SelectList(db.Users, "userId", "userName", checkOut.userId);
            return View(checkOut);
        }

        // POST: CheckOut/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ckId,quantity,ckTime,status,userId,proId")] CheckOut checkOut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkOut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proId = new SelectList(db.Products, "proId", "proName", checkOut.proId);
            ViewBag.userId = new SelectList(db.Users, "userId", "userName", checkOut.userId);
            return View(checkOut);
        }

        // GET: CheckOut/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut checkOut = db.CheckOuts.Find(id);
            if (checkOut == null)
            {
                return HttpNotFound();
            }
            return View(checkOut);
        }

        // POST: CheckOut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckOut checkOut = db.CheckOuts.Find(id);
            db.CheckOuts.Remove(checkOut);
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
