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
    public class AppointmentsController : Controller
    {
        private agendaEntities db = new agendaEntities();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.appointments.Include(a => a.brokers).Include(a => a.Customers);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appointments appointments = db.appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            return View(appointments);
        }

        // GET: Appointments/Create
        public ActionResult addAppointments()
        {
            ViewBag.idBroker = new SelectList(db.brokers, "idBroker", "lastname");
            ViewBag.idCustomer = new SelectList(db.Customers, "idCustomer", "lastname");
            return View();
        }

        // POST: Appointments/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addAppointments([Bind(Include = "idappointment,dateHour,subject,idBroker,idCustomer")] appointments appointments)
        {
            if (ModelState.IsValid)
            {
                db.appointments.Add(appointments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBroker = new SelectList(db.brokers, "idBroker", "lastname", appointments.idBroker);
            ViewBag.idCustomer = new SelectList(db.Customers, "idCustomer", "lastname", appointments.idCustomer);
            return View(appointments);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appointments appointments = db.appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBroker = new SelectList(db.brokers, "idBroker", "lastname", appointments.idBroker);
            ViewBag.idCustomer = new SelectList(db.Customers, "idCustomer", "lastname", appointments.idCustomer);
            return View(appointments);
        }

        // POST: Appointments/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idappointment,dateHour,subject,idBroker,idCustomer")] appointments appointments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBroker = new SelectList(db.brokers, "idBroker", "lastname", appointments.idBroker);
            ViewBag.idCustomer = new SelectList(db.Customers, "idCustomer", "lastname", appointments.idCustomer);
            return View(appointments);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            appointments appointments = db.appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            return View(appointments);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appointments appointments = db.appointments.Find(id);
            db.appointments.Remove(appointments);
            db.SaveChanges();
            return RedirectToAction("Index");
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
