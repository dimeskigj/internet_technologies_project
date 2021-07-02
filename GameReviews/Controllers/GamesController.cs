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
    public class GamesController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games
        [AllowAnonymous]
        public ActionResult Index() {
            return View(db.Games.ToList());
        }

        [AllowAnonymous]
        public ActionResult Search(string term) {
            return View("Index", db.Games.Where(g => g.Title.Contains(term)).ToList());
        }

        [AllowAnonymous]
        public ActionResult Sort(string criteria) {
            List<Game> games = null;
            switch (criteria) {
                case "upvotes":
                    games = db.Games.OrderByDescending(g => g.Upvotes.Count()).ThenBy(g => g.Title).ToList();
                    break;
                case "comments":
                    games = db.Games.OrderByDescending(g => g.Comments.Count()).ThenBy(g => g.Title).ToList();
                    break;
                case "title":
                    games = db.Games.OrderBy(g => g.Title).ToList();
                    break;
                default:
                    games = db.Games.ToList();
                    games.Reverse();
                    break;
            }
            return View("Index", games);
        }

        // GET: Games/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null) {
                return HttpNotFound();
            }

            CommentViewModel gameViewModel = new CommentViewModel();
            gameViewModel.GameId = id.Value;
            gameViewModel.Title = game.Title;
            gameViewModel.Comments = db.Comments.Where(c => c.GameId.Equals(id.Value)).ToList();
            gameViewModel.Upvotes = db.Upvotes.Where(u => u.GameId.Equals(id.Value)).ToList();
            gameViewModel.Game = game;

            gameViewModel.Comments.Reverse();

            return View(gameViewModel);
        }

        [Authorize]
        public ActionResult Like(int game_id, string user) {
            Game game = db.Games.ToList().Find(g => g.GameId == game_id);
            var _user = db.Users.ToList().Find(u => u.UserName == user);
            if (game == null) return HttpNotFound();

            var _upvote = db.Upvotes.ToList().Find(u => u.GameId == game_id && u.User == _user);
            if (_upvote != null) {
                // user has upvoted, remove it
                db.Upvotes.Remove(_upvote);
            }
            else {
                // user hasn't upvoted yet, add it
                db.Upvotes.Add(new Upvote { Game = game, GameId = game.GameId, User = _user, UserId = _user.Id, UserName = _user.UserName });
            }
            db.SaveChanges();
            return RedirectToAction("Details", new { id = game_id });
        }

        // GET: Games/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create() {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "GameId,Title,Description,PictureURL,SteamURL")] Game game) {
            if (ModelState.IsValid) {
                game.Comments = new List<Comment>();
                game.Upvotes = new List<Upvote>();
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null) {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "GameId,Title,Description,PictureURL,SteamURL")] Game game) {
            if (ModelState.IsValid) {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Games", new { id = game.GameId });
            }
            return View(game);
        }

        // GET: Games/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null) {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id) {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
