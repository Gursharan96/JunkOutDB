using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JunkOutDBModel;
using JunkOut.Models;
using System.Net;

namespace JunkOut.Controllers
{
    public class OrdersController : Controller
    {
        private JunkoutDBModelContainer db = new JunkoutDBModelContainer();
        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = db.Orders.Find(id);

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }



        public ActionResult Create()
        {
            return View();
        }

        // POST: Bins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdersViewModel model)
        {
            var order = model.order;

            var customer = new Customer();

            var address = new Address();

            db.Orders.Add(order);
            customer.ID = order.ID;
            db.Customers.Add(customer);

            address.ID = customer.ID;


            db.Addresses.Add(address);


            return View(model);
        }


      






        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Bins/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);

            db.Orders.Remove(order);
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



