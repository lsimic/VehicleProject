using System.Linq;
using VehicleProject.DAL;
using System;

namespace VehicleProject.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        T GetById(Guid id);
        IQueryable<T> GetAll { get; }
        void Update(T entity);
        void Delete(T entity);
    }
}
