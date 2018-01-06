using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JunkOutDBModel;

namespace JunkOut.Controllers
{
    public class TransferStationsController : Controller
    {
        private JunkoutDBModelContainer db = new JunkoutDBModelContainer();

        // GET: TransferStations
        public ActionResult Index()
        {
            return View("Index", db.TransferStations.ToList());
        }

        // GET: TransferStations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferStation transferStation = db.TransferStations.Find(id);
            if (transferStation == null)
            {
                return HttpNotFound();
            }
            return View(transferStation);
        }

        // GET: TransferStations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransferStations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StreetAddress,City,PostalCode,Country,Company,Phone,HoursOfOperation,Notes,Rate,Term")] TransferStation transferStation)
        {
            if (ModelState.IsValid)
            {
                db.TransferStations.Add(transferStation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transferStation);
        }

        // GET: TransferStations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferStation transferStation = db.TransferStations.Find(id);
            if (transferStation == null)
            {
                return HttpNotFound();
            }
            return View(transferStation);
        }

        // POST: TransferStations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StreetAddress,City,PostalCode,Country,Company,Phone,HoursOfOperation,Notes,Rate,Term")] TransferStation transferStation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transferStation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transferStation);
        }

        // GET: TransferStations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferStation transferStation = db.TransferStations.Find(id);
            if (transferStation == null)
            {
                return HttpNotFound();
            }
            return View(transferStation);
        }

        // POST: TransferStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransferStation transferStation = db.TransferStations.Find(id);
            db.TransferStations.Remove(transferStation);
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
