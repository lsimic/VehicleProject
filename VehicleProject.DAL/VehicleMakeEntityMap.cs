using System.Data.Entity.ModelConfiguration;

namespace VehicleProject.DAL
{
    public class VehicleMakeEntityMap : EntityTypeConfiguration<VehicleMakeEntity>
    {
        public VehicleMakeEntityMap()
        {
            //key
            HasKey(t => t.MakeId);

            //properties
            Property(t => t.MakeName).IsRequired();
            Property(t => t.MakeAbbr).IsRequired();

            //table
            ToTable("VehicleMakes");
        }        
    }
}
