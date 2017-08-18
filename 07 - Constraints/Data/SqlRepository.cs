using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataManager
{
    //TODO: 02 - Agrego constrain
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        DbContext _ctx;
        DbSet<T> _set;

        public SqlRepository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }
        public SqlRepository()
        {
        }
        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);
            }
        }
        public void Delete(T entity)
        {
            _set.Remove(entity);
        }
        public T FindById(int id)
        {
            return _set.Find(id);
        }
        public IQueryable<T> FindAll()
        {
            return _set;
        }
        public int Commit()
        {
            return _ctx.SaveChanges();
        }
        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
