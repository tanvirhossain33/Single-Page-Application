using Importer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.ViewModel
{
    public class TradeViewModel : BaseViewModel<Trade>
    {
        public TradeViewModel(Trade model)
        {
            Id = model.Id;

            Name = model.Name;
        }

        public string Name { get; set; }
    }

    public class TradeDetailViewModel : BaseViewModel<Trade>
    {
        public TradeDetailViewModel(Trade model)
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
