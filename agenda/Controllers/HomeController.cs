using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using agenda.Models;

namespace agenda.Controllers
{
    public class HomeController : Controller
    {
        private agendaEntities db = new agendaEntities();
        // GET: Home
        public ActionResult Index()
        {
            var appointments = db.appointments.Include(a => a.brokers).Include(a => a.Customers);
            return View(appointments.ToList());
        }
    }
}