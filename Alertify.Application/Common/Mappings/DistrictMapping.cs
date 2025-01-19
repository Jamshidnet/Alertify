using Alertify.Application.UseCases.Districts;
using Alertify.Domain.Entities;
using AutoMapper;

namespace Alertify.Application.Common.Mappings
{
    public class DistrictMapping : Profile
    {
        public DistrictMapping()
        {
            CreateMap<DistrictResponse, District>().ReverseMap();
        }
    }
}
