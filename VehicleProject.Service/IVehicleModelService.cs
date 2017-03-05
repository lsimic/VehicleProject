using VehicleProject.DAL;
using PagedList;
using System;

namespace VehicleProject.Service
{
    public interface IVehicleModelService
    {
        IPagedList<VehicleModelEntity> GetPagedVehicleModels(int pageSize, int pageNumber, string filterId, string sortTerm);
        VehicleModelEntity GetVehicleModel(Guid id);
        void CreateVehicleModel(VehicleModelEntity vehicleModelEntity, Guid MakeId);
        void UpdateVehicleModel(VehicleModelEntity vehicleModelEntity);
        void DeleteVehicleModel(VehicleModelEntity vehicleModelEntity);
    }
}
