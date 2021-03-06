﻿/*
 * Author: Jeffery Mclean
 * Controller for Tracking Bins
 *  
 */
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

namespace JunkOut.Controllers
{
    public class TrackBinsController : Controller
    {
        private JunkoutDBModelContainer db = new JunkoutDBModelContainer();

        // GET: Addresses
        public ActionResult Index()
        {
            AddressesController a = new AddressesController();

            return View(a.GetAddresses());
        }
        
    }
}
