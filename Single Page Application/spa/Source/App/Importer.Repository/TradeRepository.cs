using Importer.Model;
using Importer.ViewModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Importer.Repository
{
    public interface ITradeRepository : IGenericRepository<Trade>
    {
        List<DropdownViewModel> LoadTrades();
    }

    public class TradeRepository : BaseRepository<Trade>, ITradeRepository
    {
        private readonly BusinessDbContext _db;
        public TradeRepository(DbContext db) : base(db)
        {
            _db = db as BusinessDbContext;
        }

        public List<DropdownViewModel> LoadTrades()
        {
            return DbContext.Trades
                .Select(c => new DropdownViewModel { Id = c.Id, Name = c.Name })
                .ToList();
        }
    }
}
