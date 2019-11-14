using Importer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.ViewModel
{
    public class DocumentViewModel : BaseViewModel<Document>
    {


        public DocumentViewModel(Document model)
        {
            Id = model.Id;

            Syllabus = model.Syllabus;
            DevelopmentOfficer = model.DevelopmentOfficer;
            Manager = model.Manager;
            ActiveDate = model.ActiveDate;
            TradeId = model.TradeId;
            LevelId = model.LevelId;

            SyllabusFileName = Path.GetFileName(model.SyllabusFileName);
        }

        public string Syllabus { get; set; }
        public string DevelopmentOfficer { get; set; }
        public string Manager { get; set; }
        public DateTime ActiveDate { get; set; }

        public string TradeId { get; set; }
        public string LevelId { get; set; }

        public string SyllabusFileName { get; set; }

    }



    public class DocumentDetailViewModel : BaseViewModel<Document>
    {
        private readonly BusinessDbContext _db = new BusinessDbContext();

        public DocumentDetailViewModel(Document model)
        {
            Id = model.Id;

            Syllabus = model.Syllabus;
            DevelopmentOfficer = model.DevelopmentOfficer;
            Manager = model.Manager;
            ActiveDate = model.ActiveDate;
            TradeId = model.TradeId;
            LevelId = model.LevelId;

            Trade = GetTrade(TradeId);
            Level = GetLevel(LevelId);

            SyllabusFileName = Path.GetFileName(model.SyllabusFileName);

            Created = model.Created;
            CreatedBy = model.CreatedBy;
            Modified = model.Modified;
            ModifiedBy = model.ModifiedBy;
        }

        private string GetTrade(string id)
        {
            var item = _db.Trades.Find(id);
            return item.Name;
        }

        private string GetLevel(string id)
        {
            var item = _db.Levels.Find(id);
            return item.Name;
        }

        public string Syllabus { get; set; }
        public string DevelopmentOfficer { get; set; }
        public string Manager { get; set; }
        public DateTime ActiveDate { get; set; }

        public string TradeId { get; set; }
        public string LevelId { get; set; }

        public string Trade { get; set; }
        public string Level { get; set; }


        public string SyllabusFileName { get; set; }
    }
}
