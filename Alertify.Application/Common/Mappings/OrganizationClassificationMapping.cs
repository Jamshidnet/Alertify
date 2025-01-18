using Alertify.Application.UseCases.OrganizationClassifications;
using Alertify.Application.UseCases.Regions;
using Alertify.Domain.Entities;
using AutoMapper;

namespace Alertify.Application.Common.Mappings
{
    public class OrganizationClassificationMapping : Profile
    {
        public OrganizationClassificationMapping()
        {
            CreateMap<OrganizationClassificationResponse, OrganizationClassification>().ReverseMap();
        }
    }
}
