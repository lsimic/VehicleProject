using VehicleProject.Repository;
using PagedList;
using VehicleProject.DAL;
using System.Collections.Generic;

namespace VehicleProject.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository _vehicleMakeRepository;
        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository, IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
        }

        public IPagedList<VehicleMakeEntity> GetPagedVehicleMakes(int pageSize, int pageNumber, string sortTerm)
        {
            return _vehicleMakeRepository.GetPaged(pageSize, pageNumber, sortTerm);
        }

        public IEnumerable<VehicleMakeEntity> GetAll()
        {
            return _vehicleMakeRepository.GetAll();
        }

        public VehicleMakeEntity GetVehicleMake(int id)
        {
            return _vehicleMakeRepository.GetById(id);
        }

        public void CreateVehicleMake(VehicleMakeEntity vehicleMakeEntity)
        {
            _vehicleMakeRepository.Create(vehicleMakeEntity);
        }

        public void UpdateVehicleMake(VehicleMakeEntity vehicleMakeEntity)
        {
            _vehicleMakeRepository.Update(vehicleMakeEntity);
        }

        public void DeleteVehicleMake(VehicleMakeEntity vehicleMakeEntity)
        {
            _vehicleMakeRepository.Delete(vehicleMakeEntity);
        }
        
    }
}
