using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Importer.Model;
using Importer.Repository;
using Importer.RequestModel;
using Importer.Service;
using Importer.ViewModel;
using Newtonsoft.Json;

namespace Importer.WebApp.Controllers
{
    public abstract class BaseQueryController<T, TVm, TDVm,TRm>: ApiController
        where T: Entity
        where TVm: BaseViewModel<T>
        where TDVm: BaseViewModel<T>
        where TRm: BaseRequestModel<T>
    {
        protected DbContext DbContext;
        protected IBaseService<T, TVm, TDVm, TRm> Service;

        

        protected BaseQueryController(IBaseService<T, TVm, TDVm, TRm> service)
        {
            DbContext = new BusinessDbContext();
            Service = service;
        }


        public virtual IHttpActionResult Get(string keyword, string orderBy, string isAsc)
        {
            var request = (TRm)Activator.CreateInstance(typeof(TRm), keyword, orderBy, isAsc);
            var list = Service.GetList(request);
            return Ok(list);
        }

        public virtual IHttpActionResult Post(TRm request)
        {
            var list = Service.GetList(request);
            return Ok(list);
        }


        public IHttpActionResult Get(string request)
        {
            TRm requestModel = JsonConvert.DeserializeObject<TRm>(request);
            int count = Service.Count(requestModel);
            return Ok(count);
        }
    }
}
