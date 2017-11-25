using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JunkOutDBModel
{

    public class BinMeta
    {
        [Display(Name = "Bin Size")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]
        public string BinSize { get; set; }



        [Display(Name = "Flat Rate")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]
        public double FlatRate { get; set; }


        [Display(Name = "Minimum Tonnage Awarded")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]
        public double MinTonnageAwarded { get; set; }


        [Display(Name = "Maximum Rental Duration")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]

        public double MaxRentalDuration { get; set; }

    }

    [MetadataType(typeof(BinMeta))]
    public partial class Bin
    {


    }


    public class TransferStationMeta
    {


        [Display(Name = "Street Address")]
        [Required(ErrorMessage = " {0} required")]
        public string StreetAddress { get; set; }



        [Required(ErrorMessage = " {0} required")]
        public string City { get; set; }

        [Required(ErrorMessage = " {0} required")]

        public string Company { get; set; }

        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]
        public string Phone { get; set; }

        [Display(Name = "Hours Of Operations")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]
        public string HoursOfOperations { get; set; }


        public string Notes { get; set; }

        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]
        public string Rate { get; set; }

        [Required(ErrorMessage = " {0} required")]
        public string Terms { get; set; }



    }

    [MetadataType(typeof(TransferStationMeta))]
    public partial class TransferStation

    {


    }






    public class CustomerMeta
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = " {0} required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]
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
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Can contain Numbers Only")]
        public string PhoneNumber { get; set; }





    }

    [MetadataType(typeof(CustomerMeta))]
    public partial class Customer
    {


    }




    public class AddressMeta
    {

        [Display(Name = "Street Address")]
        [Required(ErrorMessage = " {0} required")]
        public string StreetAddress { get; set; }

        [Display(Name = "Apartment Number")]
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
        [RegularExpression("(^(?!.*[DFIOQU])[A-VXY][0-9][A-Z]●?[0-9][A-Z][0-9]$)", ErrorMessage = "Please Insert Valid Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Address Type")]
        [Required(ErrorMessage = " {0} required")]
        public string AddressType { get; set; }


    }

    [MetadataType(typeof(AddressMeta))]
    public partial class Address
    {


    }



    public class OrderMeta
    {
        [Display(Name = "Address Type")]
        [Required(ErrorMessage = " {0} required")]
        public string JobType { get; set; }

        [Display(Name = "Source of Ordering")]
        [Required(ErrorMessage = " {0} required")]
        public string SourceOfOrdering { get; set; }

        [Display(Name = "Source of hearing about us")]
        [Required(ErrorMessage = " {0} required")]
        public string HearingSource { get; set; }

        [Display(Name = "Order Notes")]
        [Required(ErrorMessage = " {0} required")]
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
