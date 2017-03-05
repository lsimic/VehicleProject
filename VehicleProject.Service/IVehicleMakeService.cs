using VehicleProject.DAL;
using PagedList;
using System.Collections.Generic;
using System;

namespace VehicleProject.Service
{
    public interface IVehicleMakeService
    {
        IPagedList<VehicleMakeEntity> GetPagedVehicleMakes(int pageSize, int pageNumber, string sortTerm);
        IEnumerable<VehicleMakeEntity> GetAll();
        VehicleMakeEntity GetVehicleMake(Guid id);
        void CreateVehicleMake(VehicleMakeEntity vehicleMakeEntity);
        void UpdateVehicleMake(VehicleMakeEntity vehiclemakeEntity);
        void DeleteVehicleMake(VehicleMakeEntity vehicleMakeEntity);
    }
}
