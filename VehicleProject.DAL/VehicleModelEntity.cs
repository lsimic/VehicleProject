namespace VehicleProject.DAL
{
    public class VehicleModelEntity : BaseEntity
    {
        public int ModelId { get; set; }
        public int VehicleMakeId { get; set; }
        public string ModelName { get; set; }
        public string ModelAbbr { get; set; }
        public virtual VehicleMakeEntity VehicleMake { get; set; }
    }
}
