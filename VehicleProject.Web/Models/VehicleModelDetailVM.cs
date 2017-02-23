using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Web.Models
{
    public class ModelMake
    {
        [Display(Name = "Vehicle make ID")]
        public int MakeId { get; set; }

        [Display(Name = "Vehicle make name")]
        public string MakeName { get; set; }

        [Display(Name = "Vehicle make abbreviation")]
        public string MakeAbbr { get; set; }
    }

    public class VehicleModelDetailVM
    {
        [Display(Name = "Vehicle model ID")]
        public int ModelId { get; set; }

        [Display(Name = "Vehicle model abbreviation")]
        public int VehicleMakeId { get; set; }

        [Display(Name = "Vehicle model name")]
        public string ModelName { get; set; }

        [Display(Name = "Vehicle model abbreviation")]
        public string ModelAbbr { get; set; }

        [Display(Name = "Vehicle make")]
        public ModelMake VehicleMake { get; set; }
    }
}