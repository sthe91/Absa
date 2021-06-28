using AutoMapper;

namespace Absa.Infrastructure.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Entry, EntityFramework.Entities.Entry>();
            CreateMap<EntityFramework.Entities.Entry, Models.Entry>();

            CreateMap<Models.Phonebook, EntityFramework.Entities.Phonebook>();
            CreateMap<EntityFramework.Entities.Phonebook, Models.Phonebook>();
        }
    }
}