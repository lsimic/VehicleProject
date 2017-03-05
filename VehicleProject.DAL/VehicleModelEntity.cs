using System;

namespace VehicleProject.DAL
{
    public class VehicleModelEntity : BaseEntity
    {
        public Guid ModelId { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string ModelName { get; set; }
        public string ModelAbbr { get; set; }
        public virtual VehicleMakeEntity VehicleMake { get; set; }
    }
}
