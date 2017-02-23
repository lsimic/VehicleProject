using VehicleProject.DAL;
using PagedList;

namespace VehicleProject.Service
{
    public interface IVehicleModelService
    {
        IPagedList<VehicleModelEntity> GetPagedVehicleModels(int pageNumber, int? filterId, string sortTerm);
        VehicleModelEntity GetVehicleModel(int id);
        void CreateVehicleModel(VehicleModelEntity vehicleModelEntity, int MakeId);
        void UpdateVehicleModel(VehicleModelEntity vehicleModelEntity);
        void DeleteVehicleModel(VehicleModelEntity vehicleModelEntity);
    }
}
