using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Absa.Infrastructure.EntityFramework.Entities
{
    public class Entry : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EntryId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public virtual Phonebook Phonebook { get; set; }
    }
}