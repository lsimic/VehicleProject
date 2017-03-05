using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VehicleProject.DAL
{
    public class VehicleMakeEntityMap : EntityTypeConfiguration<VehicleMakeEntity>
    {
        public VehicleMakeEntityMap()
        {
            //key
            HasKey(t => t.MakeId);
            Property(t => t.MakeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //properties
            Property(t => t.MakeName).IsRequired();
            Property(t => t.MakeAbbr).IsRequired();

            //table
            ToTable("VehicleMakes");
        }        
    }
}
