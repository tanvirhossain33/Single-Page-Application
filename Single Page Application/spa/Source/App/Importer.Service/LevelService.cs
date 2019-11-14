using Importer.Model;
using Importer.Repository;
using Importer.RequestModel;
using Importer.ViewModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Importer.Service
{
    public interface ILevelService
    {
        List<DropdownViewModel> LoadLevels(string input);
    }

    public class LevelService : BaseService<Level, LevelViewModel, LevelDetailViewModel, LevelRequestModel>, ILevelService
    {
        private readonly ILevelRepository _repository;

        public LevelService(ILevelRepository repository) : base((BaseRepository<Level>)repository)
        {
            _repository = Repository as LevelRepository;
        }

        public List<DropdownViewModel> LoadLevels(string input)
        {
            var list = _repository.LoadLevels(input);
            return list;
        }
    }
}
