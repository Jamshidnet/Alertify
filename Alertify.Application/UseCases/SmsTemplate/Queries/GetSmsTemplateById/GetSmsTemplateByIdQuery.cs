using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.SmsTemplates.Queries.GetSmsTemplateById
{
    public record GetSmsTemplateByIdQuery(int Id) : IRequest<SmsTemplateResponse>;

    public class GetSmsTemplateByIdQueryHandler : IRequestHandler<GetSmsTemplateByIdQuery, SmsTemplateResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetSmsTemplateByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SmsTemplateResponse> Handle(GetSmsTemplateByIdQuery request, CancellationToken cancellationToken)
        {
            var SmsTemplate = FilterIfSmsTemplateExsists(request.Id);

            var result = _mapper.Map<SmsTemplateResponse>(SmsTemplate);
            return await Task.FromResult(result);
        }

        private SmsTemplate FilterIfSmsTemplateExsists(int id)
            => _dbContext.SmsTemplates
                .Find(id) ?? throw new NotFoundException(
                    " There is no SmsTemplate with this Id. ");
    }
}
