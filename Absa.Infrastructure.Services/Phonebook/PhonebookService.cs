using System;
using System.Threading.Tasks;
using Absa.Infrastructure.EntityFramework.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Absa.Infrastructure.Services.Phonebook
{
    public class PhonebookService : BaseService<EntityFramework.Entities.Phonebook, Models.Phonebook>, IPhonebookService
    {
        public PhonebookService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
        {
        }
    }
}