using Alertify.Application.UseCases.Organizations;
using Alertify.Application.UseCases.Organizations.Commands.CreateOrganization;
using Alertify.Application.UseCases.Organizations.Commands.DeleteOrganization;
using Alertify.Application.UseCases.Organizations.Commands.UpdateOrganization;
using Alertify.Domain.Entities;
using AutoMapper;

namespace Alertify.Application.Common.Mappings
{
    public class OrganizationMapping : Profile
    {
        public OrganizationMapping()
        {
            CreateMap<CreateOrganizationCommand, Organization>().ReverseMap();
            CreateMap<UpdateOrganizationCommand, Organization>().ReverseMap();
            CreateMap<DeleteOrganizationCommand, Organization>().ReverseMap();
            CreateMap<OrganizationResponse, Organization>().ReverseMap();
        }
    }
}
