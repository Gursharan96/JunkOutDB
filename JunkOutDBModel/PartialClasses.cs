/*
 * Author: Gursharan Deol
 * Partial Classes for validating Classes
 *  
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JunkOutDBModel
{
    //Validation for Bins properties
    public class BinMeta
    {
        [Display(Name = "Bin Id")]
        public int ID { get; set; }

        [Display(Name = "Bin Size")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]
        public string BinSize { get; set; }

        [Display(Name = "Flat Rate")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([0-9]+(,[0-9]{1,3})?([.,][0-9]{1,3})?$)", ErrorMessage = "Can contain Numbers Only")]
        public double FlatRate { get; set; }

        [Display(Name = "Minimum Tonnage Awarded")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("(^[0-9]([.,][0-9]{1,3})?$)", ErrorMessage = "Can contain Numbers Only")]
        public double MinTonnageAwarded { get; set; }

        [Display(Name = "Maximum Rental Duration")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]

        public double MaxRentalDuration { get; set; }

    }

    //Validation for Bins 
    [MetadataType(typeof(BinMeta))]
    public partial class Bin
    {
    }

    //Validation for Transfer Stations properties
    public class TransferStationMeta
    {
        [Display(Name = "Transfer Station Id")]
        public int ID { get; set; }

        [Display(Name = "Street Address")]
        [Required(ErrorMessage = " {0} required")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = " {0} required")]
        public string City { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9])", ErrorMessage = "Please Insert Valid Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = " {0} required")]
        public string Country { get; set; }

        [Required(ErrorMessage = " {0} required")]
        public string Company { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("(\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4})", ErrorMessage = "Please Enter valid format")]
        public string Phone { get; set; }

        [Display(Name = "Hours Of Operations")]
        [Required(ErrorMessage = " {0} required")]
        public string HoursOfOperation { get; set; }

        public string Notes { get; set; }

        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("(^[0-9]([.,][0-9]{1,3})?$)", ErrorMessage = "Can contain Numbers Only")]
        public string Rate { get; set; }

        [Required(ErrorMessage = " {0} required")]
        public string Term { get; set; }
    }

    [MetadataType(typeof(TransferStationMeta))]
    public partial class TransferStation
    {
    }

    //Validation for Customer properties
    public class CustomerMeta
    {
        [Display(Name = "Customer Id")]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = " {0} required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = " {0} required")]
        public string LastName { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = " {0} required")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("(\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4})", ErrorMessage = "Please Enter valid format")]
        public string PhoneNumber { get; set; }

    }

    [MetadataType(typeof(CustomerMeta))]
    public partial class Customer
    {
    }

    public class AddressMeta
    {
        [Display(Name = "Address Id")]
        public int ID { get; set; }
        [Display(Name = "Street Address")]
        [Required(ErrorMessage = " {0} required")]
        public string StreetAddress { get; set; }

        [Display(Name = "Apt Num#")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]
        public string AptNum { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = " {0} required")]
        public string City { get; set; }

        [Display(Name = "Province")]
        [Required(ErrorMessage = " {0} required")]
        public string Province { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = " {0} required")]
        public string Country { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = " {0} required")]

        public string PostalCode { get; set; }

        [Display(Name = "Address Type")]
        [Required(ErrorMessage = " {0} required")]
        public string AddressType { get; set; }


    }

    [MetadataType(typeof(AddressMeta))]
    public partial class Address
    {


    }

    //Validation for Orders properties
    public class OrderMeta
    {
        [Display(Name = "Order Id")]
        public int ID { get; set; }

        [Display(Name = "Job Type")]
        [Required(ErrorMessage = " {0} required")]
        public string JobType { get; set; }

        [Display(Name = "Source of Ordering")]
        [Required(ErrorMessage = " {0} required")]
        public string SourceOfOrdering { get; set; }

        [Display(Name = "Source of hearing about us")]
        [Required(ErrorMessage = " {0} required")]
        public string HearingSource { get; set; }

        [Display(Name = "Order Notes")]
        public string OrderNotes { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = " {0} required")]
        public string Status { get; set; }

        [Display(Name = "Delivery Date/Time")]
        [Required(ErrorMessage = " {0} required")]
        [DataType(DataType.DateTime)]
        public System.DateTime DeliveryDateTime { get; set; }

        [Display(Name = "Pick Up date/Time")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> PickupDateTime { get; set; }
    }

    [MetadataType(typeof(OrderMeta))]
    public partial class Order
    {


    }



}
