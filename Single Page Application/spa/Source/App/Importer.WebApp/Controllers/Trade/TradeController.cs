using System;
using System.Web.Http;
using Importer.Model;
using Importer.Repository;
using Importer.RequestModel;
using Importer.Service;
using Importer.ViewModel;

namespace Importer.WebApp.Controllers.Document
{
    public class TradeController : BaseController<Model.Trade, TradeViewModel, TradeDetailViewModel, TradeRequestModel>
    {
        private readonly TradeService _service;

        public TradeController() : base(new TradeService(new TradeRepository(new BusinessDbContext())))
        {
            _service = new TradeService(new TradeRepository(new BusinessDbContext()));
        }

        public override IHttpActionResult Get()
        {
            var companies = _service.GetAll();

            return Ok(companies);
        }


        public override IHttpActionResult Post(Model.Trade model)
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

        public override IHttpActionResult Put(Model.Trade model)
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