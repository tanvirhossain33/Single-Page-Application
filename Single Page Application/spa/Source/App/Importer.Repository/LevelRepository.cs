using Importer.Model;
using Importer.ViewModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Importer.Repository
{
    public interface ILevelRepository : IGenericRepository<Level>
    {
        List<DropdownViewModel> LoadLevels(string input);
    }

    public class LevelRepository : BaseRepository<Level>, ILevelRepository
    {
        private readonly BusinessDbContext _db;
        public LevelRepository(DbContext db) : base(db)
        {
            _db = db as BusinessDbContext;
        }

        public List<DropdownViewModel> LoadLevels(string input)
        {
            return DbContext.Levels.Where((x => x.TradeId.ToLower().Contains(input.ToLower())))
                .Select(x => new DropdownViewModel { Id = x.Id, Name = x.Name })
                .ToList();
        }
    }
}
