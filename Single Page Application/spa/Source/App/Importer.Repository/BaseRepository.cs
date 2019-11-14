using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Importer.Model;

namespace Importer.Repository
{
    public interface IGenericRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();

        T Add(T entity);
        IQueryable<T> Add(List<T> entries);
        IQueryable<T> AddOrUpdate(List<T> saveEntries, List<T> removeEntries);
        T Get(string id);
        bool Delete(T entity);
        bool Edit(T entity);
        bool Save();

        IQueryable<T> Filter(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        IQueryable<T> Get();
    }


    public abstract class BaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        public BusinessDbContext DbContext;

        protected BaseRepository(DbContext db)
        {
            DbContext = db as BusinessDbContext;
        }


        public IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().AsQueryable();
        }


        public virtual IQueryable<TEntity> Filter(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            var query = DbContext.Set<TEntity>().AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                var properties = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var includeProperty in properties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            //    if (skip < 0) skip = 0;
            //     if (take <= 0) take = 10;
            //     query = query.Skip(skip).Take(take);

            return query.Where(x=> x.IsDeleted == false);
        }

        public virtual IQueryable<TEntity> Get()
        {
            var query = DbContext.Set<TEntity>().Where(x => x.IsDeleted == false).AsQueryable();
            return query;
        }

        public virtual TEntity Get(string id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return DbContext.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> Add(List<TEntity> entries)
        {
            return DbContext.Set<TEntity>().AddRange(entries).AsQueryable();
        }

        public IQueryable<TEntity> AddOrUpdate(List<TEntity> saveEntries, List<TEntity> removeEntries)
        {
            if (removeEntries != null) DbContext.Set<TEntity>().RemoveRange(removeEntries);
            return DbContext.Set<TEntity>().AddRange(saveEntries).AsQueryable();
        }

        public virtual bool Delete(TEntity entity)
        {
            //var remove = DbContext.Set<TEntity>().Remove(entity);
            entity.IsDeleted = true;
            entity.DeletionTime = DateTime.Now.ToUniversalTime();
            DbContext.Entry(entity).State = EntityState.Modified;

            return true;
        }

        public virtual bool Edit(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public virtual bool Save()
        {
            var changes = DbContext.SaveChanges();
            return changes > 0;
        }
       
    }
}