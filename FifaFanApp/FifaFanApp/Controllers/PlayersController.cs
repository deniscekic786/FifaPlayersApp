using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FifaFanApp.BLL;
using FifaFanApp.DAL;
using FifaFanApp.Models;
using ServiceStack;

namespace FifaFanApp.Controllers
{
    public class PlayersController : Controller
    {
        private FifaDbContext db = new FifaDbContext();

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Image).Include(p => p.Rating);

            return View(players.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Images, "Id", "PlayerPath");
            ViewBag.Id = new SelectList(db.Ratings, "Id", "Id");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(
                 Include =
                     "Id,Name,Nationality,ClubName,Position,WeakFootRating,SkillMovesRating,MinWorth,MaxWorth,Foot")] Player player, Skill skill, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var playerCtx = new PlayerRepository();
                if (file != null && file.ContentLength > 0)
                {
                    var imageResizer = new ImageProcessor.ImageResizer();
                    var playerImagePath = imageResizer.WriteImage(file.InputStream, "Player");
                    var clubNationImagePath = playerCtx.GetClubAndNationImage(player.Nationality, player.ClubName);
                    var ratingObj = FifaRatingAlgorithm.CalculateRating(skill, player.Position);
                    var playerObj = new Player
                    {
                        Name = player.Name,
                        Position = player.Position,
                        ClubName = player.ClubName,
                        Nationality = player.Nationality,
                        Foot = player.Foot,
                        MaxWorth = player.MaxWorth,
                        MinWorth = player.MinWorth,
                        SkillMovesRating = player.SkillMovesRating,
                        WeakFootRating = player.WeakFootRating,
                        Image = new Image
                        {
                            PlayerPath = playerImagePath,
                            ClubPath = clubNationImagePath.ClubPath,
                            NationalityPath = clubNationImagePath.NationalityPath
                        },
                        Rating = new Rating
                        {
                            Overall = ratingObj.Overall,
                            Pace = ratingObj.Pace,
                            Shooting = ratingObj.Shooting,
                            Dribbling = ratingObj.Dribbling,
                            Passing = ratingObj.Passing,
                            Defense = ratingObj.Defense,
                            Physical = ratingObj.Physical,
                            TotalStats = ratingObj.TotalStats
                        },
                        Skill = skill
                    };
                    playerCtx.AddPlayer(playerObj);
                }
                return RedirectToAction("Index");
            }


            ViewBag.Id = new SelectList(db.Images, "Id", "PlayerPath", player.Id);
            ViewBag.Id = new SelectList(db.Ratings, "Id", "Id", player.Id);
            return View(player);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Images, "Id", "PlayerPath", player.Id);
            ViewBag.Id = new SelectList(db.Ratings, "Id", "Id", player.Id);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(
                 Include =
                     "Id,Name,Nationality,ClubName,Position,WeakFootRating,SkillMovesRating,MinWorth,MaxWorth,Foot")] Player player, Skill skill, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Images, "Id", "PlayerPath", player.Id);
            ViewBag.Id = new SelectList(db.Ratings, "Id", "Id", player.Id);
            return View(player);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Nations()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Nations(HttpPostedFileBase file, string NationName)
        {
            if (file != null && file.ContentLength > 0)
            {
                var imageResizer = new ImageProcessor.ImageResizer();
                var path = imageResizer.WriteImage(file.InputStream, "Nation");
                var db = new FifaRepository();
                db.SaveNationInfo(new FifaNation {NationName = NationName, NationImagePath = path});
            }
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Clubs()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Clubs(HttpPostedFileBase file, string ClubName)
        {
            if (file != null && file.ContentLength > 0)
            {
                var imageResizer = new ImageProcessor.ImageResizer();
                var path = imageResizer.WriteImage(file.InputStream, "Club");
                var db = new FifaRepository();
                db.SaveClubInfo(new Models.FifaClub {ClubName = ClubName, ClubImagePath = path});
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Skills()
        {
            return View();
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
