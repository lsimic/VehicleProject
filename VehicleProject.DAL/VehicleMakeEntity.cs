using System.Collections.Generic;
using System;

namespace VehicleProject.DAL
{
    public class VehicleMakeEntity : BaseEntity
    {
        public Guid MakeId { get; set; }
        public string MakeName { get; set; }
        public string MakeAbbr { get; set; }
        public virtual ICollection<VehicleModelEntity> MakeModels { get; set; }

    }
}
