using VehicleProject.DAL;
using PagedList;
using VehicleProject.Repository;

namespace VehicleProject.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelRepository _vehicleModelRepository;
        private IVehicleMakeRepository _vehicleMakeRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository, IVehicleMakeRepository vehicleMakeRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleMakeRepository = vehicleMakeRepository;
        }



        public IPagedList<VehicleModelEntity> GetPagedVehicleModels(int pageSize, int pageNumber, string filterId, string sortTerm)
        {
            return _vehicleModelRepository.GetPaged(pageSize, pageNumber, filterId, sortTerm);
        }

        public VehicleModelEntity GetVehicleModel(int id)
        {
            return _vehicleModelRepository.GetById(id);
        }


        public void CreateVehicleModel(VehicleModelEntity vehicleModelEntity, int makeId)
        {
            VehicleMakeEntity vehicleMakeEntity = _vehicleMakeRepository.GetById(makeId);

            vehicleModelEntity.VehicleMake = vehicleMakeEntity;
            vehicleModelEntity.VehicleMakeId = makeId;

            _vehicleModelRepository.Create(vehicleModelEntity);
        }

        public void UpdateVehicleModel(VehicleModelEntity vehicleModelEntity)
        {
            _vehicleModelRepository.Update(vehicleModelEntity);
        }

        public void DeleteVehicleModel(VehicleModelEntity vehicleModelEntity)
        {
            _vehicleModelRepository.Delete(vehicleModelEntity);
        }

    }
}
