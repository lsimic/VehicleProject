using System.ComponentModel.DataAnnotations;
using System;

namespace VehicleProject.Web.Models
{
    public class BaseVM
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Abbreviation")]
        public string Abbr { get; set; }
    }
}