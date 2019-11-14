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
    public class DocumentController : BaseController<Model.Document, DocumentViewModel, DocumentDetailViewModel, DocumentRequestModel>
    {
        private readonly DocumentService _service;

        public DocumentController() : base(new DocumentService(new DocumentRepository(new BusinessDbContext())))
        {
            _service = new DocumentService(new DocumentRepository(new BusinessDbContext()));
        }

        public override IHttpActionResult Post(Model.Document model)
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

        public override IHttpActionResult Put(Model.Document model)
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