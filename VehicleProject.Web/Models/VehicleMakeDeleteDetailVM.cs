using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Web.Models
{ 
    public class MakeModel
    {
        [Display(Name = "Vehicle model Id")]
        public int ModelId { get; set; }

        [Display(Name = "Vehicle make Id")]
        public int VehicleMakeId { get; set; }

        [Display(Name = "Vehicle model name")]
        public string ModelName { get; set; }

        [Display(Name = "Vehicle model abbreviation")]
        public string ModelAbbr { get; set; }
    }

    public class VehicleMakeDeleteDetailVM
    {
        [Display(Name = "Vehicle make Id")]
        public int MakeId { get; set; }

        [Display(Name = "Vehicle make name")]
        public string MakeName { get; set; }

        [Display(Name = "Vehicle make abbreviation")]
        public string MakeAbbr { get; set; }

        [Display(Name = "Vehicle make models")]
        public virtual ICollection<MakeModel> MakeModels { get; set; }
    }
}