using VehicleProject.DAL;
using PagedList;
using System.Collections.Generic;

namespace VehicleProject.Repository
{
    public interface IVehicleMakeRepository
    {
        void Create(VehicleMakeEntity entity);
        void Update(VehicleMakeEntity entity);
        void Delete(VehicleMakeEntity entity);
        VehicleMakeEntity GetById(int id);
        IPagedList<VehicleMakeEntity> GetPaged(int pageSize, int pageNumber, string sortTerm);
        IEnumerable<VehicleMakeEntity> GetAll();
    }
}
