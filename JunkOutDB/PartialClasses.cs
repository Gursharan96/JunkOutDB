using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JunkOutDB
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



}
