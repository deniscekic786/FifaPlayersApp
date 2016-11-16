using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FifaFanApp.DAL;
using FifaFanApp.Helpers;
using FifaFanApp.Models;

namespace FifaFanApp.Controllers
{
    public class SearchController : Controller
    {
        //GET: PlayerSearch
        [Authorize]
        [HttpGet]
        public ActionResult Players()
        {
            var pageStart = 1;
            var sortStartValue = 1;
            int count = 0;
            var db = new PlayerRepository();
            var players  = db.GetAllPlayers(pageStart,10,out count);
            var pageCount = PagingExtensions.PageCount(count, 10);
            ViewBag.PageCount = pageCount;
            ViewBag.PageNumber = pageStart;
            ViewBag.SortBySelection = sortStartValue;
            return View(players);
        }


        /// <summary>
        /// Retrieves players by a filter category and the page number is used to
        /// calculate how many players will be shown on each page
        /// the default is 10 due to the amount of players being manually created
        /// </summary>
        /// <param name="sortBy"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Players(int sortBy, int pageNumber)
        {
            int count = 0;
            var db = new PlayerRepository();
            var players = db.SortPlayerBy(sortBy, pageNumber, 10, out count);
            ViewBag.PageCount = PagingExtensions.PageCount(count, 10);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SortBySelection = sortBy;
            return View(players);
        }
    }
}