using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Web.Models
{
    public class VehicleModelVM : BaseVM
    {
        [Display(Name = "Make Id")]
        public Guid MakeId { get; set; }

        [Display(Name = "Make")]
        public VehicleMakeVM Make { get; set; }
    }
}