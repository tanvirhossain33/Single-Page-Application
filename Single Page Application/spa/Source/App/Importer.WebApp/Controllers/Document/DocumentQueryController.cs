using System.Web.Http;
using Importer.Model;
using Importer.Repository;
using Importer.RequestModel;
using Importer.Service;
using Importer.ViewModel;

namespace Importer.WebApp.Controllers.Document
{
    [RoutePrefix("api/DocumentQuery")]
    public class DocumentQueryController : BaseQueryController<Model.Document, DocumentViewModel, DocumentDetailViewModel, DocumentRequestModel>
    {
        private readonly DocumentService _service;

        public DocumentQueryController() : base(new DocumentService(new DocumentRepository(new BusinessDbContext())))
        {
            _service = new DocumentService(new DocumentRepository(DbContext));
        }

        public override IHttpActionResult Post(DocumentRequestModel request)
        {
            return Ok(_service.GetAllDetails(request));
        }

    }
}