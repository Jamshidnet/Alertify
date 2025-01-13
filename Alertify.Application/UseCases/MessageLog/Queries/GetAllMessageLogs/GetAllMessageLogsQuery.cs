using AutoMapper;
using Alertify.Application.Common.Interfaces;
using Alertify.Application.UseCases.MessageLogs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Application.UseCases.MessageLogs.Queries.GetAllMessageLogs
{
    public record GetAllMessageLogsQuery : IRequest<MessageLogResponse[]>;

    public class GetAllMessageLogsQueryHandler : IRequestHandler<GetAllMessageLogsQuery, MessageLogResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllMessageLogsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<MessageLogResponse[]> Handle(GetAllMessageLogsQuery request, CancellationToken cancellationToken)
        {
            var MessageLogs = await _context.MessageLogs.ToArrayAsync();

            return _mapper.Map<MessageLogResponse[]>(MessageLogs);
        }
    }
}
