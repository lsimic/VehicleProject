using VehicleProject.Repository;
using PagedList;
using VehicleProject.DAL;
using System.Collections.Generic;

namespace VehicleProject.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleModelRepository _vehicleModelRepository;
        private IVehicleMakeRepository _vehicleMakeRepository;
        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository, IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleMakeRepository = vehicleMakeRepository;
        }

        public IPagedList<VehicleMakeEntity> GetPagedVehicleMakes(int pageNumber, string sortTerm)
        {
            return _vehicleMakeRepository.GetPaged(pageNumber, sortTerm);
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
            //when deleting a make, delete all models that make has as well.
            /*
            foreach(var vehicleModel in vehicleMakeEntity.MakeModels)
            {
                VehicleModelEntity vehicleModelToDelete = vehicleModel;
                _vehicleModelRepository.Delete(vehicleModelToDelete);
            }
            */
            _vehicleMakeRepository.Delete(vehicleMakeEntity);
        }
        
    }
}
