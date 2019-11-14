using Importer.Model;
using Importer.Repository;
using Importer.RequestModel;
using Importer.ViewModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Importer.Service
{
    public interface ITradeService
    {
        List<DropdownViewModel> LoadTrades();
    }

    public class TradeService : BaseService<Trade, TradeViewModel, TradeDetailViewModel, TradeRequestModel>, ITradeService
    {
        private readonly ITradeRepository _repository;

        public TradeService(ITradeRepository repository) : base((BaseRepository<Trade>)repository)
        {
            _repository = Repository as TradeRepository;
        }

        public List<DropdownViewModel> LoadTrades()
        {
            var list = _repository.LoadTrades();
            return list;
        }
    }
}
