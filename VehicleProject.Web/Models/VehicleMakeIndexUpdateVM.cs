using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Web.Models
{
    public class VehicleMakeIndexUpdateVM
    {
        [Display(Name = "Vehicle make Id")]
        public int MakeId { get; set; }

        [Display(Name = "Vehicle make name")]
        public string MakeName { get; set; }

        [Display(Name = "Vehicle make abbreviation")]
        public string MakeAbbr { get; set; }
    }
}