using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Absa.Infrastructure.EntityFramework.Entities;
using Absa.Infrastructure.Models;
using Absa.Infrastructure.Services;

namespace Absa.Logic
{
    public class BaseLogic<TEntity, TModel> : IBaseLogic<TEntity, TModel>
        where TEntity : BaseEntity, new()
        where TModel : BaseModel, new()
    {
        IBaseService<TEntity, TModel> _service;

        public BaseLogic(IBaseService<TEntity, TModel> service)
        {
            _service = service;
        }

        public virtual async Task<TModel> CreateAsync(TModel item)
        {
            return await _service.CreateAsync(item);
        }

        public virtual void Delete(TModel item)
        {
            _service.Delete(item);
        }

        public virtual IList<TModel> GetAll()
        {
            return _service.GetAll().ToList();
        }

        public virtual TModel GetItem(Expression<Func<TEntity, bool>> predicate)
        {
            return _service.GetItem(predicate);
        }

        public virtual IList<TModel> GetItems(Expression<Func<TEntity, bool>> predicate)
        {
            return _service.GetItems(predicate).ToList();
        }

        public virtual async Task<TModel> UpdateAsync(TModel item)
        {
            return await _service.UpdateAsync(item);
        }
    }
}