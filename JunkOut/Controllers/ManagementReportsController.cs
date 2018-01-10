/*
 * Author: Gursharan Deol, shazeen farooqi
 * Controller for Management reports
 *  
 */
using JunkOutDBModel;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JunkOut.Controllers
{
    public class ManagementReportsController : Controller
    {
        // GET: ManagementReports
        public ActionResult Index()
        {
            return View();
        }

        //Redirecting to Inventory View
        public ActionResult Inventory()
        {
            return View();
        }

        //Redirecting to Customer View
        public ActionResult Customer()
        {
            return View();
        }

        //Redirecting to Sales View
        public ActionResult Sale()
        {
            return View();
        }

        //Method for Rendering Customer Report
        public ActionResult CustomerReport(string id)
        {
            //Specify Path/ Report Name
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "CustomerInfo.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            //Make object
            List<Address> ad = new List<Address>();
            List<Customer> cust = new List<Customer>();
            List<Order> ord = new List<Order>();

            //Get data from DB
            using (JunkoutDBModelContainer jo = new JunkoutDBModelContainer())
            {
                ad = jo.Addresses.ToList();
                cust = jo.Customers.ToList();
                ord = jo.Orders.ToList();
            }

            //Data source from Report
            ReportDataSource rd = new ReportDataSource("CustomerInfo", cust);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            //Set Report
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

            //Rendering Report
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

        //Method for Rendering Job Type Vs Sorce Report
        public ActionResult JobTypeVsSource(string id)
        {
            //Setting Path
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "JobTypeVsSource.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            //Setting objects
            List<Address> ad = new List<Address>();
            List<Customer> cust = new List<Customer>();
            List<Order> ord = new List<Order>();

            //getting data from db
            using (JunkoutDBModelContainer jo = new JunkoutDBModelContainer())
            {
                ad = jo.Addresses.ToList();
                cust = jo.Customers.ToList();
                ord = jo.Orders.ToList();
            }

            //using datasource from db
            ReportDataSource rd = new ReportDataSource("JobTypeVsSource", ord);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            //Setting up the Report
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

            //Render Report
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

        //Method for Rendering Job Type Report
        public ActionResult JobTypes(string id)
        {
            //Set Path
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "JobTypes.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            //Create objects
            List<Address> ad = new List<Address>();
            List<Customer> cust = new List<Customer>();
            List<Order> ord = new List<Order>();

            //Getting data from db
            using (JunkoutDBModelContainer jo = new JunkoutDBModelContainer())
            {
                ad = jo.Addresses.ToList();
                cust = jo.Customers.ToList();
                ord = jo.Orders.ToList();
            }

            //Setting data source
            ReportDataSource rd = new ReportDataSource("JobTypes", ord);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            //Preparing report
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

            //Rendering Report
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

        //Method for Rendering Bin availability Report
        public ActionResult BinAvailability(string id)
        {
            //Setting path
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "BinAvailability.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }

            //Creating object
            List<Address> ad = new List<Address>();
            List<Customer> cust = new List<Customer>();
            List<Order> ord = new List<Order>();
            List<Bin> bins = new List<Bin>();

            //Using db
            using (JunkoutDBModelContainer jo = new JunkoutDBModelContainer())
            {
                ad = jo.Addresses.ToList();
                cust = jo.Customers.ToList();
                ord = jo.Orders.ToList();
                bins = jo.Bins.ToList();
            }

            //Specifying Datasource
            ReportDataSource rd = new ReportDataSource("BinAvailability", bins);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            //Setting report parameter
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

            //Render the Report
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

        //Method for Rendering Customer Report
        public ActionResult OrdersInCities(string id)
        {
            //set path
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), "OrdersInCities.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            //create object
            List<Address> ad = new List<Address>();
            List<Customer> cust = new List<Customer>();
            List<Order> ord = new List<Order>();
            List<Bin> bins = new List<Bin>();
            List<TransferStation> tf = new List<TransferStation>();

            //Use db
            using (JunkoutDBModelContainer jo = new JunkoutDBModelContainer())
            {
                ad = jo.Addresses.ToList();
                cust = jo.Customers.ToList();
                ord = jo.Orders.ToList();
                bins = jo.Bins.ToList();
                tf = jo.TransferStations.ToList();
            }

            // data sourec
            ReportDataSource rd = new ReportDataSource("OrdersInCities", ad);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            //Report Specifications
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

            //Render Report
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