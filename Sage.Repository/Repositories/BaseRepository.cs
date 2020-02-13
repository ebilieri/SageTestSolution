using System.Collections.Generic;
using System.Linq;
using Sage.Domain.Contracts.IRepositories;
using Sage.Repository.Context;

namespace Sage.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly SageContext SageContext;

        public BaseRepository(SageContext SageContex)
        {
            SageContext = SageContex;
        }

        public void Add(TEntity entity)
        {
            SageContext.Set<TEntity>().Add(entity);
            SageContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            SageContext.Set<TEntity>().Update(entity);
            SageContext.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return SageContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return SageContext.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            SageContext.Set<TEntity>().Remove(entity);
            SageContext.SaveChanges();
        }

        public void Dispose()
        {
            SageContext.Dispose();
        }
    }
}
