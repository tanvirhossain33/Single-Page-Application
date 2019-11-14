using Importer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.ViewModel
{
    public class LevelViewModel : BaseViewModel<Level>
    {
        public LevelViewModel(Level model)
        {
            Id = model.Id;

            Name = model.Name;            
        }
        public string Name { get; set; }
    }

    public class LevelDetailViewModel : BaseViewModel<Level>
    {
        public LevelDetailViewModel(Level model)
        {
            Id = model.Id;

            Name = model.Name;

            Created = model.Created;
            CreatedBy = model.CreatedBy;
            Modified = model.Modified;
            ModifiedBy = model.ModifiedBy;
        } 
        public string Name { get; set; }
    }
}
