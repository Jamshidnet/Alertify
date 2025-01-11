using AutoMapper;
using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Application.UseCases.SmsManagers;
using Alertify.Domain.Entities;
using MediatR;

namespace Alertify.Application.UseCases.SmsManagers.Queries.GetSmsManagerById
{
    public record GetSmsManagerByIdQuery(int Id) : IRequest<SmsManagerResponse>;

    public class GetSmsManagerByIdQueryHandler : IRequestHandler<GetSmsManagerByIdQuery, SmsManagerResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetSmsManagerByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SmsManagerResponse> Handle(GetSmsManagerByIdQuery request, CancellationToken cancellationToken)
        {
            var SmsManager = FilterIfSmsManagerExsists(request.Id);

            var result = _mapper.Map<SmsManagerResponse>(SmsManager);
            return await Task.FromResult(result);
        }

        private SmsManager FilterIfSmsManagerExsists(int id)
            => _dbContext.SmsManagers
                .Find(id) ?? throw new NotFoundException(
                    " There is no SmsManager with this Id. ");
    }
}
