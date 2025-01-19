using Alertify.Application.UseCases.SmsTemplates;
using Alertify.Application.UseCases.SmsTemplates.Commands.CreateSmsTemplate;
using Alertify.Application.UseCases.SmsTemplates.Commands.DeleteSmsTemplate;
using Alertify.Application.UseCases.SmsTemplates.Commands.UpdateSmsTemplate;
using Alertify.Domain.Entities;
using AutoMapper;

namespace Alertify.Application.Common.Mappings
{
    public class SmsTemplateMapping : Profile
    {
        public SmsTemplateMapping()
        {
            CreateMap<CreateSmsTemplateCommand, SmsTemplate>().ReverseMap();
            CreateMap<UpdateSmsTemplateCommand, SmsTemplate>().ReverseMap();
            CreateMap<DeleteSmsTemplateCommand, SmsTemplate>().ReverseMap();
            CreateMap<SmsTemplateResponse, SmsTemplate>().ReverseMap();
        }
    }
}
