using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameReviews.Models;

namespace GameReviews.Controllers {
    [Authorize]
    public class UpvotesController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Upvotes
/*        public ActionResult Index() {
            var upvotes = db.Upvotes.Include(u => u.Game);
            return View(upvotes.ToList());
        }

        // GET: Upvotes/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Upvote upvote = db.Upvotes.Find(id);
            if (upvote == null) {
                return HttpNotFound();
            }
            return View(upvote);
        }*/

        // GET: Upvotes/Create
/*        public ActionResult Create() {
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title");
            return View();
        }

        // POST: Upvotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UpvoteId,GameId,UserId")] Upvote upvote) {
            if (ModelState.IsValid) {
                db.Upvotes.Add(upvote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title", upvote.GameId);
            return View(upvote);
        }*/

        // GET: Upvotes/Edit/5
/*        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Upvote upvote = db.Upvotes.Find(id);
            if (upvote == null) {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title", upvote.GameId);
            return View(upvote);
        }

        // POST: Upvotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UpvoteId,GameId,UserId")] Upvote upvote) {
            if (ModelState.IsValid) {
                db.Entry(upvote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title", upvote.GameId);
            return View(upvote);
        }

        // GET: Upvotes/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Upvote upvote = db.Upvotes.Find(id);
            if (upvote == null) {
                return HttpNotFound();
            }
            return View(upvote);
        }

        // POST: Upvotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Upvote upvote = db.Upvotes.Find(id);
            db.Upvotes.Remove(upvote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
