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
    public class CommentsController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
/*        public ActionResult Index() {
            var comments = db.Comments.Include(c => c.Game);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null) {
                return HttpNotFound();
            }
            return View(comment);
        }*/

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CommentViewModel commentViewModel) {

            Comment comment = new Comment() {
                Text = commentViewModel.Comment,
                GameId = commentViewModel.GameId,
                Game = db.Games.Find(commentViewModel.GameId),
                DateTime = DateTime.Now,
                User = db.Users.ToList().Find(u => u.UserName == User.Identity.Name),
                UserName = User.Identity.Name
            };

            var name = User.Identity.Name;
            var user = db.Users.ToList().Find(u => u.UserName == User.Identity.Name);

            comment.UserPhotoURL = comment.User.PictureURL;
            db.Comments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Details", "Games", new { id = commentViewModel.GameId });
        }

        // GET: Comments/Create
/*        public ActionResult Create() {
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title");
            return View();
        }*/

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "CommentId,GameId,Text,DateTime,UserId")] Comment comment) {
            if (ModelState.IsValid) {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            db.Games.ToList().Find(g => g == comment.Game).Comments.Add(comment);
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title", comment.GameId);
            return View(comment);
        }

        // GET: Comments/Edit/5
/*        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null) {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "Title", comment.GameId);
            return View(comment);
        }*/

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*        [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Edit([Bind(Include = "CommentId,GameId,Text,DateTime,UserId")] Comment comment) {
                    if (ModelState.IsValid) {
                        db.Entry(comment).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    ViewBag.GameId = new SelectList(db.Games, "GameId", "Title", comment.GameId);
                    return View(comment);
                }*/

        // GET: Comments/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null) {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id) {
            Comment comment = db.Comments.Find(id);
            if (!User.IsInRole("admin") && comment.UserName != User.Identity.Name) return HttpNotFound();
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Games", new { id = comment.GameId });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
