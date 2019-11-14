using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.Model
{
    public class Level : Entity
    {
        public string Name { get; set; }
        
        public string TradeId { get; set; }
        [ForeignKey("TradeId")]
        public virtual Trade Trade { get; set; }

    }
}
