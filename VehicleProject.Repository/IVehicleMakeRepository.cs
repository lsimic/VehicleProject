using VehicleProject.DAL;
using PagedList;
using System.Collections.Generic;
using System;

namespace VehicleProject.Repository
{
    public interface IVehicleMakeRepository
    {
        void Create(VehicleMakeEntity entity);
        void Update(VehicleMakeEntity entity);
        void Delete(VehicleMakeEntity entity);
        VehicleMakeEntity GetById(Guid id);
        IPagedList<VehicleMakeEntity> GetPaged(int pageSize, int pageNumber, string sortTerm, string searchTerm);
        IEnumerable<VehicleMakeEntity> GetAll();
    }
}
