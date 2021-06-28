using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Absa.Logic
{
    public interface IBaseLogic<TEntity, TModel>
    {
        IList<TModel> GetAll();

        TModel GetItem(Expression<Func<TEntity, bool>> predicate);

        IList<TModel> GetItems(Expression<Func<TEntity, bool>> predicate);

        Task<TModel> CreateAsync(TModel item);

        Task<TModel> UpdateAsync(TModel item);

        void Delete(TModel item);
    }
}