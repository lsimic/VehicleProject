using System.Linq;
using VehicleProject.DAL;
using PagedList;

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

        public VehicleModelEntity GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public IPagedList<VehicleModelEntity> GetPaged(int pageSize, int pageNumber, int? filterId, string sortTerm)
        {
            IQueryable<VehicleModelEntity> modelEntities;

            //filtering by make. if filterId is defined, get only entites where VehicleMakeEntityId equals filterid
            //else get all entities
            if (filterId.HasValue && filterId!=0)
            {
                modelEntities = _genericRepository.GetAll.Where(
                vehicleModelEntity => vehicleModelEntity.VehicleMakeId == filterId);
            }
            else
            {
                modelEntities = _genericRepository.GetAll;
            }

            //sorting
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
                case "ByIdDescending":
                    modelEntities = modelEntities.OrderByDescending(vehicleModelEntity => vehicleModelEntity.ModelId);
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
