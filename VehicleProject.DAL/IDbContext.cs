using System.Data.Entity;

namespace VehicleProject.DAL
{
    public interface IDbContext 
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
