using System.Linq;
using VehicleProject.DAL;
using PagedList;
using System;

namespace VehicleProject.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly IGenericRepository<VehicleModelEntity> _genericRepository;
        public VehicleModelRepository(IGenericRepository<VehicleModelEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        //method implementation
        public void Create(VehicleModelEntity entity)
        {
            _genericRepository.Create(entity);
        }

        public VehicleModelEntity GetById(Guid id)
        {
            return _genericRepository.GetById(id);
        }

        public IPagedList<VehicleModelEntity> GetPaged(int pageSize, int pageNumber, string filterId, string sortTerm, string searchTerm)
        {
            IQueryable<VehicleModelEntity> modelEntities;


            //filtering:
            Guid filterMakeId = Guid.Empty;
            if(!string.IsNullOrEmpty(filterId))
            {
                filterMakeId = Guid.Parse(filterId);
            }
            
            if ((!filterMakeId.Equals(Guid.Empty))&&(string.IsNullOrEmpty(searchTerm)))
            {
                modelEntities = _genericRepository.GetAll.Where(
                vehicleModelEntity => vehicleModelEntity.VehicleMakeId == filterMakeId);
            }
            else if ((filterMakeId.Equals(Guid.Empty)) && (!string.IsNullOrEmpty(searchTerm)))
            {
                modelEntities = _genericRepository.GetAll.Where(
                vehicleModelEntity => vehicleModelEntity.ModelName.Contains(searchTerm) ||
                vehicleModelEntity.VehicleMake.MakeName.Contains(searchTerm));
            }
            else if ((!filterMakeId.Equals(Guid.Empty)) && (!string.IsNullOrEmpty(searchTerm)))
            {
                modelEntities = _genericRepository.GetAll.Where(
                vehicleModelEntity => vehicleModelEntity.VehicleMakeId == filterMakeId &&(
                vehicleModelEntity.ModelName.Contains(searchTerm) ||
                vehicleModelEntity.VehicleMake.MakeName.Contains(searchTerm)));
            }
            else
            {
                modelEntities = _genericRepository.GetAll;
            }

            //sorting:
            switch (sortTerm)
            {
                case "ByNameAscending":
                    modelEntities = modelEntities.OrderBy(vehicleModelEntity => vehicleModelEntity.ModelName);
                    break;
                case "ByNameDescending":
                    modelEntities = modelEntities.OrderByDescending(vehicleModelEntity => vehicleModelEntity.ModelName);
                    break;
                case "ByMakeNameAscending":
                    modelEntities = modelEntities.OrderBy(vehicleModelEntity => vehicleModelEntity.VehicleMake.MakeName);
                    break;
                case "ByMakeNameDescending":
                    modelEntities = modelEntities.OrderByDescending(vehicleModelEntity => vehicleModelEntity.VehicleMake.MakeName);
                    break;
                default:
                    modelEntities = modelEntities.OrderBy(vehicleModelEntity => vehicleModelEntity.ModelId);
                    break;
            }

            //return paged result
            return modelEntities.ToPagedList(pageNumber, pageSize);
        }

        public void Update(VehicleModelEntity entity)
        {
            var entityToUpdate = _genericRepository.GetById(entity.ModelId);
            entityToUpdate.ModelName = entity.ModelName;
            entityToUpdate.ModelAbbr = entity.ModelAbbr;
            _genericRepository.Update(entityToUpdate);
        }

        public void Delete(VehicleModelEntity entity)
        {
            var entityToDelete = _genericRepository.GetById(entity.ModelId);
            _genericRepository.Delete(entityToDelete);
        }
    }
}
