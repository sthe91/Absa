using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Absa.Infrastructure.EntityFramework.Entities
{
    public class Phonebook : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PhonebookId { get; set; }

        public string Name { get; set; }
    }
}