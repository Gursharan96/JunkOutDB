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

        public ActionResult Inventory()
        {
            return View();
        }

        public ActionResult Customer()
        {
            return View();
        }

        public ActionResult Sale()
        {
            return View();
        }

        public ActionResult CustomerReport(string id)
        {
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
            List<Address> ad = new List<Address>();
            List<Customer> cust = new List<Customer>();
            List<Order> ord = new List<Order>();



            using (JunkoutDBModelContainer jo = new JunkoutDBModelContainer())
            {
                ad = jo.Addresses.ToList();
                cust = jo.Customers.ToList();
                ord = jo.Orders.ToList();
            }


            ReportDataSource rd = new ReportDataSource("CustomerInfo", cust);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



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


        public ActionResult JobTypeVsSource(string id)
        {
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
            List<Address> ad = new List<Address>();
            List<Customer> cust = new List<Customer>();
            List<Order> ord = new List<Order>();



            using (JunkoutDBModelContainer jo = new JunkoutDBModelContainer())
            {
                ad = jo.Addresses.ToList();
                cust = jo.Customers.ToList();
                ord = jo.Orders.ToList();
            }


            ReportDataSource rd = new ReportDataSource("JobTypeVsSource", ord);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



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

        public ActionResult JobTypes(string id)
        {
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
            List<Address> ad = new List<Address>();
            List<Customer> cust = new List<Customer>();
            List<Order> ord = new List<Order>();



            using (JunkoutDBModelContainer jo = new JunkoutDBModelContainer())
            {
                ad = jo.Addresses.ToList();
                cust = jo.Customers.ToList();
                ord = jo.Orders.ToList();
            }


            ReportDataSource rd = new ReportDataSource("JobTypes", ord);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



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

        public ActionResult BinAvailability(string id)
        {
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
            List<Address> ad = new List<Address>();
            List<Customer> cust = new List<Customer>();
            List<Order> ord = new List<Order>();
            List<Bin> bins = new List<Bin>();



            using (JunkoutDBModelContainer jo = new JunkoutDBModelContainer())
            {
                ad = jo.Addresses.ToList();
                cust = jo.Customers.ToList();
                ord = jo.Orders.ToList();
                bins = jo.Bins.ToList();
            }


            ReportDataSource rd = new ReportDataSource("BinAvailability", bins);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



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

        public ActionResult OrdersInCities(string id)
        {
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
            List<Address> ad = new List<Address>();
            List<Customer> cust = new List<Customer>();
            List<Order> ord = new List<Order>();
            List<Bin> bins = new List<Bin>();
            List<TransferStation> tf = new List<TransferStation>();



            using (JunkoutDBModelContainer jo = new JunkoutDBModelContainer())
            {
                ad = jo.Addresses.ToList();
                cust = jo.Customers.ToList();
                ord = jo.Orders.ToList();
                bins = jo.Bins.ToList();
                tf = jo.TransferStations.ToList();
            }


            ReportDataSource rd = new ReportDataSource("OrdersInCities", ad);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



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