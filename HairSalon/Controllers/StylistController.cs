using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
        private readonly HairSalonContext _db;

        public StylistController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Stylist> model = _db.Stylists.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stylist stylist)
        {
            _db.stylists.Add(stylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            return View(thisStylist);
        }

        public ActionResult Delete(int id)
        {
            Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            return View(thisStylist);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            _db.Stylists.Remove(thisStylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}