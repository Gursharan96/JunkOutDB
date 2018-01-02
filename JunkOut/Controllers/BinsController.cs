using System;
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

        public ActionResult Report(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "JobType.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            List<Address> ad = new List<Address>();
            List<Customer> cust = new List<Customer>();
            List<Order> ord = new List<Order>();



            using (JunkoutDBModelContainer jo = new JunkoutDBModelContainer())
            {
                ad = jo.Addresses.ToList();
                cust = jo.Customers.ToList();
                ord = jo.Orders.ToList();
            }


            ReportDataSource rd = new ReportDataSource("JobType", ord);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
                );
            return File(renderedBytes, mimeType);
        }
    }
}
