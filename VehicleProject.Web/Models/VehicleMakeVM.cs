using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Web.Models
{
    public class VehicleMakeVM : BaseVM
    {
        [Display(Name="Models")]
        public ICollection<VehicleModelVM> MakeModels { get; set; }
    }
}