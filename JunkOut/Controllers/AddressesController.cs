/*
 * Author: Gursharan Deol
 * APIs for Address
 *  
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using JunkOutDBModel;

namespace JunkOut.Controllers
{
    public class AddressesController : ApiController
    {
        private JunkoutDBModelContainer db = new JunkoutDBModelContainer();

        // GET: api/Addresses
        public IQueryable<Address> GetAddresses()
        {
            /*
            List<Address> add = new List<Address>();
            var queryOrder = (from o in db.Orders
                             where o.Status == "Delivered"
                             select o).ToList();

            if((queryOrder.Count > 0) || (queryOrder != null) )
            {
                foreach (Order ord in queryOrder)
                {
                    Customer cust = ord.Customers.First();
                    Address a = cust.Addresses.First();
                    add.Add(a);
                }
                // return db.Addresses;
                return add.AsQueryable();
            }
            */
             return db.Addresses;
        }



        // GET: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult GetAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.ID)
            {
                return BadRequest();
            }

            db.Entry(address).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Addresses
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(address);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = address.ID }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(address);
            db.SaveChanges();

            return Ok(address);
        }
        // DISPOSE: to close DB connection
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // Find: To find some address
        private bool AddressExists(int id)
        {
            return db.Addresses.Count(e => e.ID == id) > 0;
        }

        //To stop Lazy loading
        public AddressesController() : base()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

    }
}