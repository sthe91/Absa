using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Absa.Infrastructure.EntityFramework.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Absa.Infrastructure.Services.Entry
{
    public class EntryService : BaseService<EntityFramework.Entities.Entry, Models.Entry>, IEntryService
    {
        public EntryService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
        {
        }
        public override async Task<Models.Entry> CreateAsync(Models.Entry item)
        {
            try
            {
                var entity = _mapper.Map<EntityFramework.Entities.Entry>(item);

                entity.Phonebook = await _appDbContext.Phonebooks.FindAsync(item.Phonebook.PhonebookId);

                var entityEntry = _appDbContext.Entries.Add(entity);

                await _appDbContext.SaveChangesAsync().ConfigureAwait(continueOnCapturedContext: false);

                return item;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                throw;
            }
        }

        public override async Task<Models.Entry> UpdateAsync(Models.Entry item)
        {
            try
            {
                var entity = _mapper.Map<EntityFramework.Entities.Entry>(item);

                entity.Phonebook = await _appDbContext.Phonebooks.FindAsync(item.Phonebook.PhonebookId);

                var entityEntry = _appDbContext.Entries.Update(entity);

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

        public List<Models.Entry> Search(string searchText)
        {
            try
            {
                var entities = _appDbContext.Entries.FromSqlRaw($"spSearchEntries {searchText}");

                return _mapper.Map<List<Models.Entry>>(entities.ToList());
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                throw;
            }
        }
    }
}