using Absa.Infrastructure.Models;

namespace Absa.UI.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public ContactViewModel()
        {

        }

        public ContactViewModel(Phonebook phonebook)
        {
            Entry = new Entry(phonebook);
        }

        public Entry Entry { get; set; }
    }
}