using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JunkOutDBModel;
using JunkOut.Models;
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Text;

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
            /*
            var order = model.order;


            db.Orders.Add(order);

            /*
            var customer = new Customer() {

                FirstName = model.customer.FirstName,
                LastName = model.customer.LastName,
                CompanyName = model.customer.CompanyName,
                Email = model.customer.Email,
                PhoneNumber = model.customer.PhoneNumber

                };

             */

            Customer customer = model.customer;


            Address address = model.address;
            Order order = model.order;



            db.Customers.Add(customer);
            db.Addresses.Add(address);

            customer.Addresses.Add(address);

            var queryBin= from b in db.Bins
                          where b.Status == "Available"
                          select b;

            Bin bin = queryBin.First();


          //  Bin bin = db.Bins.First();
            order.Bin = bin;
            order.Status = "New";
            order.SourceOfOrdering = "Call In";

            db.Orders.Add(order);

            order.Customers.Add(customer);

          

           




            db.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ordervm = new OrdersViewModel();

            {

                Order order = db.Orders.SingleOrDefault(o => o.ID == id);

                Customer customer = order.Customers.First();

                Address address = customer.Addresses.First();


                if (order == null)
                {
                    return HttpNotFound();
                }


                ordervm.order = order;
                ordervm.customer = customer;
                ordervm.address = address;

               

                // Retrieve list of States
                
            }
            return View(ordervm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( OrdersViewModel model)
        {
            if (ModelState.IsValid)
            {
                Order order = model.order;
                Customer customer = model.customer;
                Address address = model.address;


                db.Entry(order).State = EntityState.Modified;
                db.Entry(customer).State = EntityState.Modified;
                db.Entry(address).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
                return View(model);
        }


      





        /*
                public ActionResult Edit(int? id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    OrdersViewModel model = new OrdersViewModel();
                    Order order = model.order;
                    order = db.Orders.Find(id);
                    if (order == null)
                    {
                        return HttpNotFound();
                    }
                    return View(model);
                }

                // POST: Bins/Edit/5
                // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
                // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost, ActionName("Edit")]
                [ValidateAntiForgeryToken]
                public ActionResult EditPost(int? id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }


                    var courseToUpdate = db.Orders.Find(id);

                        try
                        {
                            db.SaveChanges();

                            return RedirectToAction("Index");
                        }

                        catch (RetryLimitExceededException )
                        {
                            //Log the error (uncomment dex variable name and add a line here to write a log.
                            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                        }

                    return View(courseToUpdate);
                }


                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Edit(OrdersViewModel model)
                {

                    if (ModelState.IsValid)
                    {
                        Order order = model.order;
                        Customer customer = model.customer;
                        Address address = model.address;

                        db.Entry(order).State = EntityState.Modified;
                        db.Entry(customer).State = EntityState.Modified;
                        db.Entry(address).State = EntityState.Modified;

                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(model);
                }
        */



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


            Customer customer = order.Customers.FirstOrDefault<Customer>();



            order.Customers.Remove(customer);
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



