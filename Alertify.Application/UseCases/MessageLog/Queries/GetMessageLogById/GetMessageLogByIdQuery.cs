using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.MessageLogs.Queries.GetMessageLogById
{
    public record GetMessageLogByIdQuery(int Id) : IRequest<MessageLogResponse>;

    public class GetMessageLogByIdQueryHandler : IRequestHandler<GetMessageLogByIdQuery, MessageLogResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetMessageLogByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MessageLogResponse> Handle(GetMessageLogByIdQuery request, CancellationToken cancellationToken)
        {
            var MessageLog = FilterIfMessageLogExsists(request.Id);

            var result = _mapper.Map<MessageLogResponse>(MessageLog);
            return await Task.FromResult(result);
        }

        private MessageLog FilterIfMessageLogExsists(int id)
            => _dbContext.MessageLogs
                .Find(id) ?? throw new NotFoundException(
                    " There is no MessageLog with this Id. ");
    }
}
