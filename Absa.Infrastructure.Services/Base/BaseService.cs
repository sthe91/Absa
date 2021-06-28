using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Absa.Infrastructure.EntityFramework.Data;
using Absa.Infrastructure.EntityFramework.Entities;
using Absa.Infrastructure.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Absa.Infrastructure.Services
{
    public class BaseService<TEntity, TModel> : IBaseService<TEntity, TModel>
        where TEntity : BaseEntity, new()
        where TModel : BaseModel, new()
    {
        public readonly AppDbContext _appDbContext;
        public IMapper _mapper;

        public BaseService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public virtual IList<TModel> GetAll()
        {
            try
            {
                var entities = _appDbContext.Set<TEntity>().AsNoTracking();

                foreach (var property in _appDbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    entities = entities.Include(property.Name);

                return _mapper.Map<IList<TModel>>(entities);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                throw;
            }
        }

        public virtual TModel GetItem(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var entities = _appDbContext.Set<TEntity>().AsNoTracking();

                foreach (var property in _appDbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    entities = entities.Include(property.Name);

                var entity = entities.FirstOrDefault(predicate);

                return _mapper.Map<TModel>(entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                throw;
            }
        }

        public virtual IList<TModel> GetItems(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var query = _appDbContext.Set<TEntity>().AsNoTracking();

                foreach (var property in _appDbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    query = query.Include(property.Name);

                var entities = query.Where(predicate);

                return _mapper.Map<IList<TModel>>(entities);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                throw;
            }
        }

        public virtual async Task<TModel> CreateAsync(TModel item)
        {
            try
            {
                var entity = _mapper.Map(item, typeof(TModel), typeof(TEntity));

                var entityEntry = _appDbContext.Set<TEntity>().Add((TEntity)entity);

                await _appDbContext.SaveChangesAsync().ConfigureAwait(continueOnCapturedContext: false);

                return item;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                throw;
            }
        }

        public virtual async Task<TModel> UpdateAsync(TModel item)
        {
            try
            {
                var entity = (TEntity)_mapper.Map(item, typeof(TModel), typeof(TEntity));

                var entityEntry = _appDbContext.Set<TEntity>().Update((TEntity)entity);

                await _appDbContext.SaveChangesAsync();

                entityEntry.State = EntityState.Detached;

                return item;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                throw;
            }
        }

        public void Delete(TModel item)
        {
            try
            {
                var entity = (TEntity)_mapper.Map(item, typeof(TModel), typeof(TEntity));

                var entityEntry = _appDbContext.Set<TEntity>().Attach(entity);
                entityEntry = _appDbContext.Set<TEntity>().Remove(entity);

                _appDbContext.SaveChanges();

                entityEntry.State = EntityState.Detached;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                throw;
            }
        }
    }
}