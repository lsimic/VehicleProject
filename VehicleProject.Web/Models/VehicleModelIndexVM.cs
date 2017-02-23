using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Web.Models
{
    public class VehicleModelIndexVM
    {
        [Display(Name = "Vehicle model ID")]
        public int ModelId { get; set; }

        [Display(Name = "Vehicle model name")]
        public string ModelName { get; set; }

        [Display(Name = "Vehicle model abbreviation")]
        public string ModelAbbr { get; set; }

        [Display(Name = "Vehicle Make Name")]
        public string MakeName { get; set; }
    }
}