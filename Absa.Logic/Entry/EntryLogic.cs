using System.Collections.Generic;
using Absa.Infrastructure.Services.Entry;

namespace Absa.Logic.Entry
{
    public class EntryLogic : BaseLogic<Infrastructure.EntityFramework.Entities.Entry, Infrastructure.Models.Entry>, IEntryLogic
    {
        private readonly IEntryService _service;
        private List<Infrastructure.Models.Entry> entries;

        public EntryLogic(IEntryService service) : base(service)
        {
            _service = service;
        }

        public IList<Infrastructure.Models.Entry> Search(string searchText)
        {
            return _service.Search(searchText);
        }
    }
}