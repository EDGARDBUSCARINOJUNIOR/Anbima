using AutoMapper;
using Anbima.Application.Services;
using Anbima.Application.Services.Interfaces;

namespace Anbima.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<AnbimaService, IAnbimaService>();
        }
    }
}
