using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JunkOutDBModel;

namespace CustomerForms.Models
{
    public class CustomerFormModel
    {
        public Address address { get; set; }
        public Order order { get; set; }
        public Customer customer { get; set; }
        public List<OrderList> ol { get; set; }

        public CustomerFormModel()
        {
            ol = new List<OrderList>();
        }


    }
    public class OrderList{
        public string jt { get; set; }
    }

    public enum Prov
    {
        ON,
        QC,
        NB,
        NS,
        MB,
        BC,
        PE,
        SK,
        AB,
        NL
    }

    public enum Site
    {
        Residence,
        Household,
        Office,
        Apartment
    }
}