using System.Collections.Generic;
using Absa.Infrastructure.Models;

namespace Absa.UI.ViewModels
{
    public class ContactListViewModel
    {
        public ContactListViewModel()
        {

        }

        public ContactListViewModel(string phonebookId)
        {
            PhonebookId = phonebookId;
            Entries = new List<Entry>();
        }

        public string PhonebookId { get; set; }

        public List<Entry> Entries { get; set; }
    }
}