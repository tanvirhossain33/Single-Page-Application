using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Importer.RequestModel
{
    public abstract class BaseRequestModel<TModel>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PerPageCount { get; set; }

        public int Page { get; set; }
        public List<string> Tables { get; set; }
        public string Id { get; set; }
        protected OrderByRequest Request;
        public string Keyword { get; set; }
        public string ParentId { get; set; }

        protected Expression<Func<TModel, bool>> ExpressionObj = e => true;

        protected abstract Expression<Func<TModel, bool>> GetExpression();


        protected BaseRequestModel(string keyword, string orderBy, string isAscending, int? perPageCount = 10)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                keyword = "";
            }
            Page = 1;
            PerPageCount = perPageCount.HasValue ? perPageCount.GetValueOrDefault() : 10;
            Keyword = keyword.ToLower();
            Request = new OrderByRequest
            {
                PropertyName = string.IsNullOrWhiteSpace(orderBy) ? "Modified" : orderBy,
                IsAscending = isAscending == "True"
            };
        }        

        protected Func<IQueryable<TSource>, IOrderedQueryable<TSource>> OrderByFunc<TSource>()
        {
            string propertyName = Request.PropertyName;
            bool ascending = Request.IsAscending;
            var source = Expression.Parameter(typeof(IQueryable<TSource>), "source");
            var item = Expression.Parameter(typeof(TSource), "item");
            var member = Expression.Property(item, propertyName);
            var selector = Expression.Quote(Expression.Lambda(member, item));
            var body = Expression.Call(
                typeof(Queryable), @ascending ? "OrderBy" : "OrderByDescending",
                new[] { item.Type, member.Type },
                source, selector);
            var expr = Expression.Lambda<Func<IQueryable<TSource>, IOrderedQueryable<TSource>>>(body, source);
            var func = expr.Compile();
            return func;
        }
        

        public IQueryable<TModel> GetOrderedData(IQueryable<TModel> queryable)
        {
            queryable = queryable.Where(GetExpression());
            queryable = OrderByFunc<TModel>()(queryable);
            return queryable;
        }

        public IQueryable<TModel> SkipAndTake(IQueryable<TModel> queryable)
        {
            if (Page>0 && Keyword == "")
            {
                queryable = queryable.Skip((Page - 1) * PerPageCount).Take(PerPageCount);
            }
            else if (Page > 0 && Keyword.Any())
            {
                queryable = queryable.Skip((Page - 1) * PerPageCount).Take(PerPageCount);
            }
            else
            {
                Page = 1;
                queryable = queryable.Skip((Page - 1) * PerPageCount).Take(PerPageCount);
            }
            
            return queryable;
        }

        public IQueryable<TModel> GetData(IQueryable<TModel> queryable)
        {
            return queryable.Where(GetExpression());
        }

        public TModel GetFirstData(IQueryable<TModel> queryable)
        {
            return queryable.First(GetExpression());
        }
    }
}