using VehicleProject.DAL;
using PagedList;
using System.Collections.Generic;

namespace VehicleProject.Service
{
    public interface IVehicleMakeService
    {
        IPagedList<VehicleMakeEntity> GetPagedVehicleMakes(int pageNumber, string sortTerm);
        IEnumerable<VehicleMakeEntity> GetAll();
        VehicleMakeEntity GetVehicleMake(int id);
        void CreateVehicleMake(VehicleMakeEntity vehicleMakeEntity);
        void UpdateVehicleMake(VehicleMakeEntity vehiclemakeEntity);
        void DeleteVehicleMake(VehicleMakeEntity vehicleMakeEntity);
    }
}
