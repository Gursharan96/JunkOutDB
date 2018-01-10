/*
 * Author: Gursharan Deol/Jeffery Mclean
 * Controller for Orders
 * ADD/EDIT/DELETE/GET
 *  
 */
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
            return View("Index", orderList);

        }

        //Deatils
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

        //Sorting data for filters
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
                else if (jobTypes.Contains(item) && form[item].Substring(0, 1).Equals("t"))
                {
                    checkedJobTypes[countJobTypes++] = item;
                }
                else if (form[item] == "deliveryAsc")
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

            if (orderByDeliveryDesc)
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

        //Create new Order
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdersViewModel model, FormCollection frm)
        {
            //Getting delivery and pickup date from form 
            String del = frm["delivery"].ToString();
            String pickup = frm["pickup"].ToString();

            //Creating new objects from model
            Customer customer = model.customer;
            Address address = model.address;
            Order order = model.order;

            //Add customer
            db.Customers.Add(customer);
            //Add Address
            db.Addresses.Add(address);
            //Add relation for Customer-Address
            customer.Addresses.Add(address);

            //Find available bin
            var queryBin = (from b in db.Bins
                            where b.Status == "Available"
                            select b).ToList();
            //Check is bin is avialable
            if (queryBin.Count > 0)
            {

                Bin bin = queryBin.First();
                order.DeliveryDateTime = DateTime.Parse(del);
                order.PickupDateTime = DateTime.Parse(pickup);
                order.Bin = bin;
                order.Status = "Confirmed";
                order.SourceOfOrdering = "Call In";

                //Adding Orders
                db.Orders.Add(order);
                //Adding order-Customer relation
                order.Customers.Add(customer);

                bin.Status = "Booked";
                db.SaveChanges();

                //If successful redirect to index
                return RedirectToAction("Index");

            }
            //If no bin is Avaialable
            ViewBag.Message = "Out of Bins";
            return View("Create");
        }

        //Edit Method
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
            }
            //Return a model from DB
            return View(ordervm);
        }

        //Edit Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdersViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Model
                Order order = model.order;
                Customer customer = model.customer;
                Address address = model.address;

                //if state is modeified - data is changed
                db.Entry(order).State = EntityState.Modified;
                db.Entry(customer).State = EntityState.Modified;
                db.Entry(address).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                //Catching Errors
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
            //If Successful Redirect to Index
            return RedirectToAction("Index");
        }

        //Delete Method 
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

            //Remove Relationship od order Customer
            order.Customers.Remove(customer);
            //Delete order
            db.Orders.Remove(order);
            //Set Bin status to Avaialable
            bin.Status = "Available";

            Address address = customer.Addresses.FirstOrDefault<Address>();

            //Remove customer-Address realtion
            customer.Addresses.Remove(address);
            //Delete Customer
            db.Customers.Remove(customer);
            //Delete Address
            db.Addresses.Remove(address);
            //save chnages
            db.SaveChanges();
            //Redirect to Index if successful
            return RedirectToAction("Index");
        }

        //Close Db connections
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
