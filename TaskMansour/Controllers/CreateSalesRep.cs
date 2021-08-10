using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskMansour.Models;

namespace TaskMansour.Controllers
{
    public class CreateSalesRep : Controller
    {
        private readonly DataBaseContext db;
        public CreateSalesRep(DataBaseContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(db.SalesReps.ToList());
        }
        [HttpPost]
        public IActionResult Add(SalesRep sales)
        {
            db.SalesReps.Add(sales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("AddSalesRep")]
        public IActionResult Add()
        {

            return PartialView("_Add");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = db.SalesReps.Find(id);
            db.SalesReps.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
