using AutoMapper;
using Alertify.Application.Common.Interfaces;
using Alertify.Application.UseCases.SmsTemplates;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Application.UseCases.SmsTemplates.Queries.GetAllSmsTemplates
{
    public record GetAllSmsTemplatesQuery : IRequest<SmsTemplateResponse[]>;

    public class GetAllSmsTemplatesQueryHandler : IRequestHandler<GetAllSmsTemplatesQuery, SmsTemplateResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllSmsTemplatesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<SmsTemplateResponse[]> Handle(GetAllSmsTemplatesQuery request, CancellationToken cancellationToken)
        {
            var SmsTemplates = await _context.SmsTemplates.ToArrayAsync();

            return _mapper.Map<SmsTemplateResponse[]>(SmsTemplates);
        }
    }
}
