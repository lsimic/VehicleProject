﻿using System.Linq;
using VehicleProject.DAL;
using PagedList;
using System.Collections.Generic;

namespace VehicleProject.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {

        private readonly IGenericRepository<VehicleMakeEntity> _genereicRepository;
        public VehicleMakeRepository(IGenericRepository<VehicleMakeEntity> genericRepository)
        {
            _genereicRepository = genericRepository;
        }

        //method implementation
        public void Create(VehicleMakeEntity entity)
        {
            _genereicRepository.Create(entity);
        }

        public VehicleMakeEntity GetById(int id)
        {
            return _genereicRepository.GetById(id);
        }

        public IEnumerable<VehicleMakeEntity> GetAll()
        {
            return _genereicRepository.GetAll;
        }


        public IPagedList<VehicleMakeEntity> GetPaged(int pageNumber, string sortTerm)
        {
            //pagesize is constant value, defined here. could be deifned elsewhere and propagated here.
            int pageSize = 5;
            IQueryable<VehicleMakeEntity> makeEntities = _genereicRepository.GetAll;

            //sorting
            switch (sortTerm)
            {
                case "ByNameAscending":
                    makeEntities = makeEntities.OrderBy(vehicleMake => vehicleMake.MakeName);
                    break;
                case "ByNameDescending":
                    makeEntities = makeEntities.OrderByDescending(vehicleMake => vehicleMake.MakeName);
                    break;
                case "ByIdDescending":
                    makeEntities = makeEntities.OrderByDescending(vehicleMake => vehicleMake.MakeId);
                    break;
                default:
                    makeEntities = makeEntities.OrderBy(vehicleMake => vehicleMake.MakeId);
                    break;
            }

            //returning paged result
            //querry executes here
            return makeEntities.ToPagedList(pageNumber, pageSize);
        }

        public void Update(VehicleMakeEntity entity)
        {
            var entityToUpdate = _genereicRepository.GetById(entity.MakeId);
            entityToUpdate.MakeName = entity.MakeName;
            entityToUpdate.MakeAbbr = entity.MakeAbbr;
            _genereicRepository.Update(entityToUpdate);
        }

        public void Delete(VehicleMakeEntity entity)
        {
            var entityToDelete = _genereicRepository.GetById(entity.MakeId);
            _genereicRepository.Delete(entityToDelete);
        }
    }
}