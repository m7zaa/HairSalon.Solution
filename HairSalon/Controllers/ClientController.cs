
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using System;
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

        public ActionResult Index()
        {
            List<Client> model = _db.Clients.Include(clients => clients.Stylist).ToList();
            return View(model);
        }





        // [HttpGet("/Client/Create")]
        public ActionResult Create()
        {
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
            return View();

        }

        // @*[HttpGet("/Stylist/{id}/Client/Create", Name = "StylistClient")]
        // public ActionResult Create(int id)
        // {
        //     ViewBag.StylistId = new SelectList(new List<Stylist> { _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id) }, "StylistId", "Name");
        //     return View();
        // }*@






        // [HttpPost("/Client/Create")]
        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // @*[HttpPost("/Stylist/{stylistId}/Client/Create")]
        // public ActionResult Create(int stylistId, Client client)
        // {
        //     _db.Clients.Add(client);
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }*@



        //changed stylist => stylist.StylistId == id) from client
        public ActionResult Details(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            return View(thisClient);
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
        }
    }
}