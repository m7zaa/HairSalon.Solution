
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        private readonly HairSalonContext _db;

        public ClientController(HairSalonContext db)
        {
            _db = db;
        }

        // public ActionResult Index()
        // {
        //     List<Stylist> model = _db.Stylist.ToList();
        //     return View(model);
        // }
        [HttpGet("Client/Create/{stylistId}")]
        public ActionResult Create(int stylistId)
        {
            ViewBag.StylistId = stylistId;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            int id = client.StylistId;
            return RedirectToAction("Details", "Stylist", id);
        }

        public ActionResult Delete(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
            return View(thisClient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
            int stylistId = thisClient.StylistId;
            _db.Clients.Remove(thisClient);
            _db.SaveChanges();
            return RedirectToAction("Details", "Stylist", stylistId);
        }    }
}