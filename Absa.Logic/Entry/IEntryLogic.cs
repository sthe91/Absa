using System.Collections.Generic;

namespace Absa.Logic.Entry
{
    public interface IEntryLogic : IBaseLogic<Infrastructure.EntityFramework.Entities.Entry, Infrastructure.Models.Entry>
    {
        IList<Infrastructure.Models.Entry> Search(string searchText);
    }
}