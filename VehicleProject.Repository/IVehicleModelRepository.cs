using VehicleProject.DAL;
using PagedList;
using System;

namespace VehicleProject.Repository
{
    public interface IVehicleModelRepository
    {
        void Create(VehicleModelEntity entity);
        void Update(VehicleModelEntity entity);
        void Delete(VehicleModelEntity entity);
        VehicleModelEntity GetById(Guid id);
        IPagedList<VehicleModelEntity> GetPaged(int pageSize, int pageNumber, string filterId, string sortTerm, string searchTerm);
    }
}
