﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using JunkoutDBModel;
using JunkOutDBModel;

using Microsoft.Reporting.WebForms;

using System.IO;


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

            // return View(binList);
              return View("Index",binList);
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
        

        public ActionResult SortStatus(string status, string binSize)
        {
            IEnumerable<Bin> binList = db.Bins.ToList();
            if(!status.Equals("all") && !status.Equals(""))
            {
                binList = binList.Where(Bins => Bins.Status == status);
            }

            if(!binSize.Equals("all") && !binSize.Equals(""))
            {
                binList = binList.Where(Bins => Bins.BinSize == binSize);
            }

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

                bin.Status = "New";

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
