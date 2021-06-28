using System;
using System.ComponentModel.DataAnnotations;

namespace Absa.Infrastructure.Models
{
    public class Entry : BaseModel
    {
        public Entry()
        {
            Phonebook = new Phonebook();
        }

        public Entry(Phonebook phonebook)
        {
            Phonebook = phonebook;
        }

        public Guid EntryId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public Phonebook Phonebook { get; set; }
    }
}