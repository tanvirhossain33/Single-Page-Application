using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Importer.Model;
using Importer.Repository;
using Importer.RequestModel;
using Importer.ViewModel;

namespace Importer.Service
{
    public interface IBaseService<T, TVm, out TDVm, in TRm>
        where T : Entity
        where TVm : BaseViewModel<T>
        where TDVm : BaseViewModel<T>
        where TRm : BaseRequestModel<T>
    {
        List<T> GetAll();
        T Get(string id);
        T GetAsNoTracking(string id);
        bool Add(T entity);
        bool Add(List<T> entries);
        bool Edit(T entity);        
        bool Delete(T entity);
        bool Delete(string id);

        List<TVm> GetList(TRm requestModel);
        int Count(TRm requestModel);
        TDVm GetDetail(string id);
    }


    public abstract class BaseService<T, TVm, TDVm, TRm> : IBaseService<T, TVm, TDVm, TRm> 
        where T : Entity 
        where TVm : BaseViewModel<T>
        where TDVm : BaseViewModel<T>
        where TRm : BaseRequestModel<T>
    {
        protected BaseRepository<T> Repository;

        protected BaseService(BaseRepository<T> repository)
        {
            Repository = repository;
        }

        public virtual List<T> GetAll()
        {
            var list = Repository.Get().ToList();

            return list;
        }

        public virtual T Get(string id)
        {
            return Repository.Get(id);
        }

        public virtual T GetAsNoTracking(string id)
        {
            return Repository.Filter(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }

        public virtual bool Add(T entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id)) entity.Id = Guid.NewGuid().ToString();
            var add = Repository.Add(entity);
            var save = Repository.Save();
            return save;
        }

        public virtual bool Add(List<T> entries)
        {
            foreach (var entry in entries)
            {
                if (string.IsNullOrWhiteSpace(entry.Id)) entry.Id = Guid.NewGuid().ToString();
            }

            IEnumerable<T> add = Repository.Add(entries).AsEnumerable();
            bool save = Repository.Save();
            return save;
        }

        public virtual bool Edit(T entity)
        {
            bool edit = Repository.Edit(entity);
            Repository.Save();
            return edit;
        }

        public virtual bool Delete(T entity)
        {
            bool deleted = Repository.Delete(entity);
            Repository.Save();
            return deleted;
        }

        public virtual bool Delete(string id)
        {
            var entity = Repository.Filter(x => x.Id == id).FirstOrDefault();
            bool deleted = false;
            if (entity != null)
            {
                deleted = Repository.Delete(entity);
                Repository.Save();                
            }
            return deleted;
        }        

        
        //*****************to base transfar methodes *************************
        public virtual List<TVm> GetList(TRm requestModel)
        {
            var queryable = requestModel.GetOrderedData(Repository.Get());
            queryable = requestModel.SkipAndTake(queryable);
            var viewModels = queryable.ToList().ConvertAll(x => (TVm)Activator.CreateInstance(typeof(TVm), x));
            return viewModels;
        }

        public virtual int Count(TRm requestModel)
        {
            var queryable = requestModel.GetOrderedData(Repository.Get());
            var count = queryable.Count();
            return count;
        }

        public virtual TDVm GetDetail(string id)
        {
            var entity = Repository.Filter(x => x.Id == id).FirstOrDefault();
            return entity != null ? (TDVm)Activator.CreateInstance(typeof(TDVm), entity) : null;
        }


    }
}