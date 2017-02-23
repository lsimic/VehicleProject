using System.Collections.Generic;

namespace VehicleProject.DAL
{
    public class VehicleMakeEntity : BaseEntity
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public string MakeAbbr { get; set; }
        public virtual ICollection<VehicleModelEntity> MakeModels { get; set; }

    }
}
