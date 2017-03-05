﻿using VehicleProject.DAL;
using PagedList;

namespace VehicleProject.Repository
{
    public interface IVehicleModelRepository
    {
        void Create(VehicleModelEntity entity);
        void Update(VehicleModelEntity entity);
        void Delete(VehicleModelEntity entity);
        VehicleModelEntity GetById(int id);
        IPagedList<VehicleModelEntity> GetPaged(int pageSize, int pageNumber, string filterId, string sortTerm);
    }
}
