using System.Collections.Generic;
using System.Web.Http;
using Importer.Model;
using Importer.Repository;
using Importer.RequestModel;
using Importer.Service;
using Importer.ViewModel;

namespace Importer.WebApp.Controllers.Document
{
    [RoutePrefix("api/LevelQuery")]
    public class LevelQueryController : BaseQueryController<Model.Level, LevelViewModel, LevelDetailViewModel, LevelRequestModel>
    {
        private readonly LevelService _service;

        public LevelQueryController() : base(new LevelService(new LevelRepository(new BusinessDbContext())))
        {
            _service = new LevelService(new LevelRepository(DbContext));
        }

        [HttpGet]
        public IHttpActionResult LoadLevels(string input)
        {
            List<DropdownViewModel> list = _service.LoadLevels(input);
            return Ok(list);
        }
    }
}