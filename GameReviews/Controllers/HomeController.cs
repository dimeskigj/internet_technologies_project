using GameReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameReviews.Controllers {
    [AllowAnonymous]
    public class HomeController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index() {
            Game game = db.Games.ToList().Last();
            return View(game);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}