using Importer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Importer.RequestModel
{
    public class TradeRequestModel : BaseRequestModel<Trade>
    {
        public TradeRequestModel(string keyword, string orderBy, string isAscending) : base(keyword, orderBy, isAscending)
        {
        }


        protected override Expression<Func<Trade, bool>> GetExpression()
        {
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = x => x.Name.ToLower().Contains(Keyword);
            }

            return ExpressionObj;
        }
    }
}
