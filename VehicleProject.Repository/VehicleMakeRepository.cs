using System.Linq;
using VehicleProject.DAL;
using PagedList;
using System.Collections.Generic;
using System;

namespace VehicleProject.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {

        private readonly IGenericRepository<VehicleMakeEntity> _genericRepository;
        public VehicleMakeRepository(IGenericRepository<VehicleMakeEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        //method implementation
        public void Create(VehicleMakeEntity entity)
        {
            _genericRepository.Create(entity);
        }

        public VehicleMakeEntity GetById(Guid id)
        {
            return _genericRepository.GetById(id);
        }

        public IEnumerable<VehicleMakeEntity> GetAll()
        {
            return _genericRepository.GetAll;
        }


        public IPagedList<VehicleMakeEntity> GetPaged(int pageSize, int pageNumber, string sortTerm, string searchTerm)
        {
            IQueryable<VehicleMakeEntity> makeEntities;

            //flitering:
            if (!string.IsNullOrEmpty(searchTerm))
            {
                makeEntities = _genericRepository.GetAll.Where(
                vehicleMakeEntity => vehicleMakeEntity.MakeName.Contains(searchTerm));
            }
            else
            {
                makeEntities = _genericRepository.GetAll;
            }

            //sorting:
            switch (sortTerm)
            {
                case "ByNameAscending":
                    makeEntities = makeEntities.OrderBy(vehicleMake => vehicleMake.MakeName);
                    break;
                case "ByNameDescending":
                    makeEntities = makeEntities.OrderByDescending(vehicleMake => vehicleMake.MakeName);
                    break;
                default:
                    makeEntities = makeEntities.OrderBy(vehicleMake => vehicleMake.MakeId);
                    break;
            }

            //returning paged result
            return makeEntities.ToPagedList(pageNumber, pageSize);
        }

        public void Update(VehicleMakeEntity entity)
        {
            var entityToUpdate = _genericRepository.GetById(entity.MakeId);
            entityToUpdate.MakeName = entity.MakeName;
            entityToUpdate.MakeAbbr = entity.MakeAbbr;
            _genericRepository.Update(entityToUpdate);
        }

        public void Delete(VehicleMakeEntity entity)
        {
            var entityToDelete = _genericRepository.GetById(entity.MakeId);
            _genericRepository.Delete(entityToDelete);
        }
    }
}
