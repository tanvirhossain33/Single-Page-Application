using System;
using System.Web.Http;
using Importer.Model;

using Importer.Repository;
using Importer.RequestModel;
using Importer.Service;
using Importer.ViewModel;

namespace Importer.WebApp.Controllers
{
    public interface IBaseController<in T>  where T : Entity
    {
        IHttpActionResult Post(T model);
        IHttpActionResult Put(T model);
        IHttpActionResult Delete(string id);
    }

    public abstract class BaseController<T, TVm, TDVm, TRm> : ApiController, IBaseController<T>
        where T : Entity
        where TVm : BaseViewModel<T>
        where TDVm : BaseViewModel<T>
        where TRm : BaseRequestModel<T>
    {
        protected BusinessDbContext DbContext;
        protected BaseService<T, TVm, TDVm, TRm> Service;
        
        protected ValidationResponse ValidationResponse;

        protected BaseController(BaseService<T, TVm, TDVm, TRm> service)
        {
            DbContext = new BusinessDbContext();
            Service = service;
           
            ValidationResponse = new ValidationResponse();
        }

        public virtual IHttpActionResult Get(string id)
        {
            var model = Service.GetDetail(id);
            return Ok(model);
        }


        public virtual IHttpActionResult Post(T model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            model.Id = Guid.NewGuid().ToString();
            model.Created = Convert.ToDateTime(model.Created);
            model.Modified = Convert.ToDateTime(model.Modified);

            var add = Service.Add(model);
            return Ok(model.Id);
        }

        public virtual IHttpActionResult Put(T model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            model.Created = Convert.ToDateTime(model.Created);
            model.Modified = Convert.ToDateTime(model.Modified);

            var edit = Service.Edit(model);
            return Ok(edit);
        }

        public virtual IHttpActionResult Delete(string id)
        {
            var delete = Service.Delete(id);            
            return Ok(delete);
        }

        public virtual IHttpActionResult Get()
        {
            var list = Service.GetAll();

            return Ok(list);
        }

    }
}