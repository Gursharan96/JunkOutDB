/*
 * Author: Gursharan Deol
 * View Model for Creating new Orders
 *  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JunkOutDBModel;
//using JunkoutModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace JunkOut.Models
{
    public class OrdersViewModel
    {
        // Class with mustiply properties
        public Order order { get; set; }
        public Customer customer { get; set; }
        public Address address { get; set; }

    }
}