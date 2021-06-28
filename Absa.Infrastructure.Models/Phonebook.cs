using System;
namespace Absa.Infrastructure.Models
{
    public class Phonebook : BaseModel
    {
        public Phonebook()
        {
            PhonebookId = Guid.NewGuid();
        }

        public Guid PhonebookId { get; set; }

        public string Name { get; set; }
    }
}