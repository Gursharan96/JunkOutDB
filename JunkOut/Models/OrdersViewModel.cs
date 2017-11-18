using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JunkOutDBModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace JunkOut.Models
{
    public class OrdersViewModel
    {
        
        public Order order { get; set; }

        public Customer customer { get; set; }
        public Address address { get; set; }

        public Bin bin { get; set; }

        public TransferStation transferStation { get; set; }


       
     //   public List<SelBin> SelBins { get; set; }

     //   public List<SelTranferStation> SelTranferStations { get; set; }



/*
        public OrdersViewModel()
        {
            SelBins = new List<SelBin>();
            SelTranferStations = new List<SelTranferStation>();

        }

    */
    }

    /*
    public class SelBin
    {

        public int Id { get; set; }

        public bool isBinSelected { get; set; }

        public string Name { get; set; }
    }

    public class SelTranferStation
    {

        public int Id { get; set; }

        public bool isTranferStationSelected { get; set; }

        public string Address { get; set; }
    }
    */

}