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
            IEnumerable<Order> orderList = (IEnumerable<Order>)TempData["sortedList"];

            if (orderList == null)
            {
                orderList = db.Orders.ToList();
            }
            return View(orderList);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order orderList = db.Orders.Find(id);

            if (orderList == null)
            {
                return HttpNotFound();
            }
            return View(orderList);
        }

        public ActionResult SortOrders(FormCollection form)
        {
            IEnumerable<Order> orderList = db.Orders.ToList();
            string[] statuses = { "New", "Pending", "Confirmed", "Delivered", "Completed" };
            string[] jobTypes = { "Bin Rental", "Junk Removal", "Demolition" };
            string[] checkedStatuses = new string[5];
            string[] checkedJobTypes = new string[3];
            int countStatus = 0;
            int countJobTypes = 0;

            bool orderByDeliveryDesc = true;
            foreach (string item in form)
            {
                if (statuses.Contains(item) && form[item].Substring(0, 1).Equals("t"))
                {
                    checkedStatuses[countStatus++] = item;
                }
                else if(jobTypes.Contains(item) && form[item].Substring(0, 1).Equals("t"))
                {
                    checkedJobTypes[countJobTypes++] = item;
                }
                else if(form[item] == "deliveryAsc")
                {
                    orderByDeliveryDesc = false;
                }
                        

            }
            orderList = orderList.Where(Orders => Orders.Status == checkedStatuses[0] ||
                                                Orders.Status == checkedStatuses[1] ||
                                                Orders.Status == checkedStatuses[2] ||
                                                Orders.Status == checkedStatuses[3] ||
                                                Orders.Status == checkedStatuses[4]);

            orderList = orderList.Where(Orders => Orders.JobType == checkedJobTypes[0] ||
                                                Orders.JobType == checkedJobTypes[1] ||
                                                Orders.JobType == checkedJobTypes[2]);

            if(orderByDeliveryDesc)
            {
                orderList = orderList.OrderByDescending(Orders => Orders.DeliveryDateTime);
            }
            else
            {
                orderList = orderList.OrderBy(Orders => Orders.DeliveryDateTime);
            }
            

            TempData["sortedList"] = orderList;
            return RedirectToAction("Index");
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
            order.Status = "Confirmed";
            order.SourceOfOrdering = "Call In";

            db.Orders.Add(order);

            order.Customers.Add(customer);

            bin.Status = "Booked";

           




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
            return RedirectToAction("Index");
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


            Customer customer = order.Customers.FirstOrDefault<Customer>();

            Bin bin = order.Bin;

          

            order.Customers.Remove(customer);
            db.Orders.Remove(order);

            bin.Status = "Available";

            Address address = customer.Addresses.FirstOrDefault<Address>();

            customer.Addresses.Remove(address);

            db.Customers.Remove(customer);
            db.Addresses.Remove(address);




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



