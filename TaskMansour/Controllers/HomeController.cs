using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskMansour.Models;

namespace TaskMansour.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataBaseContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DataBaseContext _db)
        {
            _logger = logger;
            db = _db;
        }
        public IActionResult Index()
        {
            return View(db.Pos.Include(ww => ww.SalesRep).ToList());
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult AddVisit(Pos pos)
        {
            if (ModelState.IsValid)
            {
                db.Pos.Add(pos);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddVisit(int id)
        {
            List<SalesRep> salseList = db.SalesReps.ToList();
            var model = new Pos();
            SelectList list = null;
            if (id == 0)
            {
                list = new SelectList(salseList, "SalesRepID", "SalesRepName");

            }
            else
            {
                model = db.Pos.Find(id);
                list = new SelectList(salseList, "SalesRepID", "SalesRepName", model.PosID);
            }
            ViewBag.MyList = list;
            return PartialView("_AddVisit", model);
        }
        [HttpPost]
        public IActionResult updateVisit(Pos pos)
        {
            if (ModelState.IsValid)
            {
                db.Pos.Update(pos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SalesRep> salseList = db.SalesReps.ToList();
            var list = new SelectList(salseList, "SalesRepID", "SalesRepName");
            ViewBag.MyList = list;
            return PartialView("_AddVisit", pos);
        }
        [HttpGet]
        public IActionResult deleteVisit(int id)
        {
            var pos = db.Pos.Find(id);
            db.Pos.Remove(pos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
