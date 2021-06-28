using Absa.Infrastructure.Services.Phonebook;

namespace Absa.Logic.Phonebook
{
    public class PhonebookLogic : BaseLogic<Infrastructure.EntityFramework.Entities.Phonebook, Infrastructure.Models.Phonebook>, IPhonebookLogic
    {
        public PhonebookLogic(IPhonebookService service) : base(service)
        {
        }
    }
}