using Alertify.Application.UseCases.Regions;
using Alertify.Domain.Entities;
using AutoMapper;

namespace Alertify.Application.Common.Mappings
{
    public class RegionMapping : Profile
    {
        public RegionMapping()
        {
            CreateMap<RegionResponse, Region>().ReverseMap();
        }
    }
}
