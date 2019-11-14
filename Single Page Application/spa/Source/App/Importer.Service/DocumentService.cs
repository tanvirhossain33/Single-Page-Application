using Importer.Model;
using Importer.Repository;
using Importer.RequestModel;
using Importer.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Importer.Service
{
    public interface IDocumentService
    {
        List<DocumentDetailViewModel> GetAllDetails(DocumentRequestModel request);
    }

    public class DocumentService : BaseService<Document, DocumentViewModel, DocumentDetailViewModel, DocumentRequestModel>, IDocumentService
    {
        private readonly IDocumentRepository _repository;

        public DocumentService(IDocumentRepository repository) : base((BaseRepository<Document>)repository)
        {
            _repository = Repository as DocumentRepository;
        }

        public List<DocumentDetailViewModel> GetAllDetails(DocumentRequestModel request)
        {
            var queryable = request.GetOrderedData(Repository.Get());
            queryable = request.SkipAndTake(queryable);
            var viewModels = queryable.ToList().ConvertAll(x => (DocumentDetailViewModel)Activator.CreateInstance(typeof(DocumentDetailViewModel), x));
            return viewModels;
        }
    }
}
