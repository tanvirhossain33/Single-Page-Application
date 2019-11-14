using Importer.Model;
using Importer.Repository;
using Importer.RequestModel;
using Importer.Service;
using Importer.ViewModel;
using System.Collections.Generic;
using System.Web.Http;

namespace Importer.WebApp.Controllers.Document
{
    [RoutePrefix("api/TradeQuery")]
    public class TradeQueryController : BaseQueryController<Model.Trade, TradeViewModel, TradeDetailViewModel, TradeRequestModel>
    {
        private readonly TradeService _service;

        public TradeQueryController() : base(new TradeService(new TradeRepository(new BusinessDbContext())))
        {
            _service = new TradeService(new TradeRepository(DbContext));
        }

        [HttpGet]
        public IHttpActionResult LoadTrades()
        {
            List<DropdownViewModel> list = _service.LoadTrades();
            return Ok(list);
        }
    }
}