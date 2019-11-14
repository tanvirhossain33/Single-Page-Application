using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Importer.Model;
using Importer.Repository;
using Importer.RequestModel;
using Importer.Service;
using Importer.ViewModel;

namespace Importer.WebApp.Controllers.Document
{
    public class LevelController : BaseController<Model.Level, LevelViewModel, LevelDetailViewModel, LevelRequestModel>
    {
        private readonly LevelService _service;

        public LevelController() : base(new LevelService(new LevelRepository(new BusinessDbContext())))
        {
            _service = new LevelService(new LevelRepository(new BusinessDbContext()));
        }

        public override IHttpActionResult Get()
        {
            var companies = _service.GetAll();
            return Ok(companies);
        }


        public override IHttpActionResult Post(Model.Level model)
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

        public override IHttpActionResult Put(Model.Level model)
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

        
    }
}