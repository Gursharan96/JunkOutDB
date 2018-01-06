using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JunkOutDBModel;
using CustomerForms.Models;

namespace CustomerForms.Controllers
{
    public class HomeController : Controller
    {
        private JunkoutDBModelContainer db = new JunkoutDBModelContainer();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(CustomerFormModel cfm, FormCollection frm)
        //public ActionResult Index(string fname, string bintwo, string binone, string jobtype)
        {
            String jt = frm["jobtype"].ToString();
            String del = frm["delivery"].ToString();
            String pickup = frm["pickup"].ToString();

            cfm.address.Country = "Canada";
            db.Customers.Add(cfm.customer);
            db.Addresses.Add(cfm.address);

            Customer c = db.Customers.Find(cfm.customer.ID);
            Address a = db.Addresses.Find(cfm.address.ID);
            c.Addresses.Add(a);

            var queryBin = from b in db.Bins
                           where b.Status == "Available"
                           select b;

            Bin bin = queryBin.First();

            cfm.orders.Bin = bin;

            cfm.orders.SourceOfOrdering = "Online";
            cfm.orders.JobType = jt;
            cfm.orders.DeliveryDateTime = DateTime.Parse(del);
            cfm.orders.PickupDateTime = DateTime.Parse(pickup);
            db.Orders.Add(cfm.orders);

            Order o = db.Orders.Find(cfm.orders.ID);
            c.Orders.Add(o);

            cfm.orders.Status = "New";

            bin.Status = "Booked";

            db.SaveChanges();
               
           // return RedirectToAction("Confirmation");
            return View("Confirmation");

            //return Content($"Hello {fname} {jobtype} {bintwo} {binone}");
            //return View();
        }
            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(db.Addresses.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Confirmation()
        {
            ViewBag.Message = "Confirmation Page";

            return View();
        }
    }
}