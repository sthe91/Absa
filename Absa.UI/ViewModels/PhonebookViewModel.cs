using System;
using Absa.Infrastructure.Models;

namespace Absa.UI.ViewModels
{
    public class PhonebookViewModel : BaseViewModel
    {
        public PhonebookViewModel()
        {
            Phonebook = new Phonebook();
        }

        public Phonebook Phonebook { get; set; }
    }
}