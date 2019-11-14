using Importer.Model;
using System.Data.Entity;

namespace Importer.Repository
{
    public interface IDocumentRepository : IGenericRepository<Document>
    {
    }
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(DbContext db) : base(db)
        {

        }
    }
}
