using System.Data.Entity.ModelConfiguration;

namespace VehicleProject.DAL
{
    class VehicleModelEntityMap : EntityTypeConfiguration<VehicleModelEntity>
    {
        public VehicleModelEntityMap()
        {
            //key
            HasKey(t => t.ModelId);


            //properties
            Property(t => t.ModelName).IsRequired();
            Property(t => t.ModelAbbr).IsRequired();
            Property(t => t.VehicleMakeId);
            //table
            ToTable("VehicleModels");

            //relationship
            HasRequired(t => t.VehicleMake)
                .WithMany(c => c.MakeModels)
                .HasForeignKey(t => t.VehicleMakeId);
        }
    }
}
