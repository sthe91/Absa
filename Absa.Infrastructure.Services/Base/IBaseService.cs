using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Absa.Infrastructure.Services
{
    public interface IBaseService<TEntity, TModel>
    {
        IList<TModel> GetAll();

        TModel GetItem(Expression<Func<TEntity, bool>> predicate);

        IList<TModel> GetItems(Expression<Func<TEntity, bool>> predicate);

        Task<TModel> CreateAsync(TModel item);

        Task<TModel> UpdateAsync(TModel item);

        void Delete(TModel item);
    }
}