using System.Collections.Generic;
using Absa.Infrastructure.Models;

namespace Absa.UI.ViewModels
{
    public class PhonebookListViewModel
    {
        public PhonebookListViewModel()
        {
            Phonebooks = new List<Phonebook>();
        }

        public List<Phonebook> Phonebooks { get; set; }
    }
}