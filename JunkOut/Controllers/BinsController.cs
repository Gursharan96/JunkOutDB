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
    public class BinsController : Controller
    {
        private JunkoutDBModelContainer db = new JunkoutDBModelContainer();
        

        // GET: Bins
        public ActionResult Index()
        {
            IEnumerable<Bin> binList = (IEnumerable<Bin>) TempData["sortedList"];

            if (binList == null)
            {
                binList = db.Bins.ToList();
            }

            return View(binList);
        }

        // GET: Bins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bin bin = db.Bins.Find(id);
            if (bin == null)
            {
                return HttpNotFound();
            }
            return View(bin);
        }


        public ActionResult SortBins(FormCollection form)
        {
            IEnumerable<Bin> binList = db.Bins.ToList();
            string[] statuses = { "New", "Available", "pending", "Booked", "delivered"};
            string[] sizes = { "5", "10", "14" };
            string[] checkedStatuses = new string[5];
            string[] checkedSizes= new string[3];
            int countStatus = 0;
            int countSizes = 0;
            foreach (string item in form)
            {
                if (statuses.Contains(item) && form[item].Substring(0, 1).Equals("t"))
                {
                    checkedStatuses[countStatus++] = item;
                }

                if (sizes.Contains(item) && form[item].Substring(0, 1).Equals("t"))
                {
                    checkedSizes[countSizes++] = item;
                }

            }
            binList = binList.Where(Bins => Bins.Status == checkedStatuses[0] ||
                                                Bins.Status == checkedStatuses[1] ||
                                                Bins.Status == checkedStatuses[2] ||
                                                Bins.Status == checkedStatuses[3] ||
                                                Bins.Status == checkedStatuses[4]);

            binList = binList.Where(Bins => Bins.BinSize == checkedSizes[0] ||
                                                Bins.BinSize == checkedSizes[1] ||
                                                Bins.BinSize == checkedSizes[2]);

            TempData["sortedList"] = binList;
            return RedirectToAction("Index");
        }

        // GET: Bins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BinSize,FlatRate,MinTonnageAwarded,MaxRentalDuration,Status")] Bin bin)
        {
            if (ModelState.IsValid)
            {

                bin.Status = "Available";

                db.Bins.Add(bin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bin);
        }

        // GET: Bins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bin bin = db.Bins.Find(id);
            if (bin == null)
            {
                return HttpNotFound();
            }
            return View(bin);
        }

        // POST: Bins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BinSize,FlatRate,MinTonnageAwarded,MaxRentalDuration,Status")] Bin bin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bin);
        }

        // GET: Bins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bin bin = db.Bins.Find(id);
            if (bin == null)
            {
                return HttpNotFound();
            }
            return View(bin);
        }

        // POST: Bins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bin bin = db.Bins.Find(id);
            db.Bins.Remove(bin);
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
