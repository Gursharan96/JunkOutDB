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
    public class BestRouteController : Controller
    {
        private JunkoutDBModelContainer db = new JunkoutDBModelContainer();

        // GET: BestRoute
        public ActionResult Index()
        {
            var transferStations = db.TransferStations.Include(t => t.Expens);
            return View(transferStations.ToList());
        }

        // GET: BestRoute/Details/5
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

        // GET: BestRoute/Create
        public ActionResult Create()
        {
            ViewBag.Expen_ID = new SelectList(db.Expenses, "ID", "DisposalCost");
            return View();
        }

        // POST: BestRoute/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StreetAddress,City,PostalCode,Country,Company,Phone,HoursOfOperation,Notes,Rate,Term,Expen_ID")] TransferStation transferStation)
        {
            if (ModelState.IsValid)
            {
                db.TransferStations.Add(transferStation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Expen_ID = new SelectList(db.Expenses, "ID", "DisposalCost", transferStation.Expen_ID);
            return View(transferStation);
        }

        // GET: BestRoute/Edit/5
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
            ViewBag.Expen_ID = new SelectList(db.Expenses, "ID", "DisposalCost", transferStation.Expen_ID);
            return View(transferStation);
        }

        // POST: BestRoute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StreetAddress,City,PostalCode,Country,Company,Phone,HoursOfOperation,Notes,Rate,Term,Expen_ID")] TransferStation transferStation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transferStation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Expen_ID = new SelectList(db.Expenses, "ID", "DisposalCost", transferStation.Expen_ID);
            return View(transferStation);
        }

        // GET: BestRoute/Delete/5
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

        // POST: BestRoute/Delete/5
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
