using Alertify.Application.UseCases.SmsManagers;
using Alertify.Application.UseCases.SmsManagers.Commands.CreateSmsManager;
using Alertify.Application.UseCases.SmsManagers.Commands.DeleteSmsManager;
using Alertify.Application.UseCases.SmsManagers.Commands.UpdateSmsManager;
using Alertify.Domain.Entities;
using AutoMapper;

namespace Alertify.Application.Common.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<CreateSmsManagerCommand, SmsManager>().ReverseMap();
            CreateMap<UpdateSmsManagerCommand, SmsManager>().ReverseMap();
            CreateMap<DeleteSmsManagerCommand, SmsManager>().ReverseMap();
            CreateMap<SmsManagerResponse, SmsManager>().ReverseMap();
        }
    }
}
