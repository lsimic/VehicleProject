using System.Linq;
using VehicleProject.DAL;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;

namespace VehicleProject.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        public GenericRepository(IDbContext context)
        {
            _context = context;
        }

        private IDbSet<T> entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }

        //Create method implementation
        public void Create(T entity)
        {
            entities.Add(entity);
            _context.SaveChanges();           
        }

        //ReadById Method implementation
        public T GetById(int id)
        {
            return entities.Find(id);
        }

        //ReadAll Method implementation
        public virtual IQueryable<T> GetAll
        {
            get
            {
                return entities;
            }
        }

        //update method implementation
        public void Update(T entity)
        {
            entities.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        //delete method implementation
        public void Delete(T entity)
        {
                        
            entities.Attach(entity);
            entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
