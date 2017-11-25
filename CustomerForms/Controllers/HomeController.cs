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
        public ActionResult Index(CustomerFormModel cfm)
        // public ActionResult Index(string fname, string bintwo, string binone, string jobtype)
        {

             if (ModelState.IsValid)
              {
                  db.Customers.Add(cfm.customer);
                  db.SaveChanges();
                  return RedirectToAction("About");
              } 

            // return Content($"Hello {fname} {jobtype} {bintwo} {binone}");
            return View();
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
    }
}