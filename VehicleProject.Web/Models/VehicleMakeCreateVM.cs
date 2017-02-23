using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Web.Models
{
    public class VehicleMakeCreateVM
    {
        [Display(Name = "Vehicle make name")]
        public string MakeName { get; set; }

        [Display(Name = "Vehicle make abbreviation")]
        public string MakeAbbr { get; set; }
    }
}