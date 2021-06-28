using System.Collections.Generic;

namespace Absa.Infrastructure.Services.Entry
{
    public interface IEntryService : IBaseService<EntityFramework.Entities.Entry, Models.Entry>
    {
        List<Models.Entry> Search(string searchText);
    }
}