using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Web.Models
{
    public class VehicleModelCreateVM
    {
        [Display(Name = "Vehicle make abbreviation")]
        public string MakeId { get; set; }

        [Display(Name = "Vehicle make abbreviation")]
        public string ModelName { get; set; }

        [Display(Name = "Vehicle make abbreviation")]
        public string ModelAbbr { get; set; }
    }
}