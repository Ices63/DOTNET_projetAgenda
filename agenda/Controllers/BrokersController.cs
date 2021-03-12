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
    public class BrokersController : Controller
    {
        private agendaEntities db = new agendaEntities();

        // GET: Brokers
        public ActionResult listBrokers()
        {
            return View(db.brokers.ToList());
        }

        // GET: Brokers/Details/5
        public ActionResult profilBrokers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            brokers brokers = db.brokers.Find(id);
            if (brokers == null)
            {
                return HttpNotFound();
            }
            return View(brokers);
        }

        // GET: Brokers/Create
        public ActionResult addBrokers()
        {
            return View();
        }

        // POST: Brokers/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addBrokers([Bind(Include = "idBroker,lastname,firstname,mail,phoneNumber")] brokers brokers)
        {
            if (ModelState.IsValid)
            {
                db.brokers.Add(brokers);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(brokers);
        }

        // GET: Brokers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            brokers brokers = db.brokers.Find(id);
            if (brokers == null)
            {
                return HttpNotFound();
            }
            return View(brokers);
        }

        // POST: Brokers/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBroker,lastname,firstname,mail,phoneNumber")] brokers brokers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brokers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("listBrokers");
            }
            return View(brokers);
        }

        // GET: Brokers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            brokers brokers = db.brokers.Find(id);
            if (brokers == null)
            {
                return HttpNotFound();
            }
            return View(brokers);
        }

        // POST: Brokers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            brokers brokers = db.brokers.Find(id);
            db.brokers.Remove(brokers);
            db.SaveChanges();
            return RedirectToAction("listBrokers");
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
