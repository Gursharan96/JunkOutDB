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

            IEnumerable<TransferStation> transferStationList = 
                (IEnumerable<TransferStation>)TempData["sortedList"];

            if (transferStationList == null)
            {
                transferStationList = db.TransferStations.ToList();
            }
           
            return View("Index",transferStationList);


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

        public ActionResult SortStations(FormCollection form)
        {
           IEnumerable<TransferStation> transferStationList = db.TransferStations.ToList();
            string[] cities = { "Brampton", "Mississauga", "Booked", "delivered" };
            string[] checkedStatuses = new string[5];
            int countStatus = 0;
            int selectedRate = 0;//default value
            //System.Diagnostics.Debug.WriteLine(transferStationList);

            string selectedCity = form[0]; //get city value from form dropdown
            
            //check for input in rate field
            if(form[1] != "")
            {
                int.TryParse(form[1], out var num);//try to parse the rate filter. output to num variable.
                selectedRate = num; // set the rate to the num variable.
            }
            
            


            //If value has changed, filter list
            if (selectedRate != 0)
            {
                transferStationList = transferStationList.Where
                    (TransferStation => int.Parse(TransferStation.Rate) < selectedRate);
            }

            //if city has been selected
            if(selectedCity != "")
            {
                transferStationList = transferStationList.Where
                    (TransferStation => TransferStation.City == selectedCity);
            }
            
            TempData["sortedList"] = transferStationList; 
            return RedirectToAction("Index");
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
