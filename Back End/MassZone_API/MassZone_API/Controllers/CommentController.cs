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
    public class CommentController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Comment
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Posts).Include(c => c.Products).Include(c => c.Users);
            return View(comments.ToList());
        }

        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            ViewBag.postId = new SelectList(db.Posts, "postId", "title");
            ViewBag.proId = new SelectList(db.Products, "proId", "proName");
            ViewBag.userId = new SelectList(db.Users, "userId", "userName");
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cmtId,content,postId,userId,proId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.postId = new SelectList(db.Posts, "postId", "title", comment.postId);
            ViewBag.proId = new SelectList(db.Products, "proId", "proName", comment.proId);
            ViewBag.userId = new SelectList(db.Users, "userId", "userName", comment.userId);
            return View(comment);
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.postId = new SelectList(db.Posts, "postId", "title", comment.postId);
            ViewBag.proId = new SelectList(db.Products, "proId", "proName", comment.proId);
            ViewBag.userId = new SelectList(db.Users, "userId", "userName", comment.userId);
            return View(comment);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cmtId,content,postId,userId,proId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.postId = new SelectList(db.Posts, "postId", "title", comment.postId);
            ViewBag.proId = new SelectList(db.Products, "proId", "proName", comment.proId);
            ViewBag.userId = new SelectList(db.Users, "userId", "userName", comment.userId);
            return View(comment);
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
