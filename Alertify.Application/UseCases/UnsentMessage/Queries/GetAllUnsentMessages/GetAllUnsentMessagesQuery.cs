using Alertify.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Application.UseCases.UnsentMessages.Queries.GetAllUnsentMessages
{
    public record GetAllUnsentMessagesQuery : IRequest<UnsentMessageResponse[]>;

    public class GetAllUnsentMessagesQueryHandler : IRequestHandler<GetAllUnsentMessagesQuery, UnsentMessageResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllUnsentMessagesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UnsentMessageResponse[]> Handle(GetAllUnsentMessagesQuery request, CancellationToken cancellationToken)
        {
            var UnsentMessages = await _context.UnsentMessages.ToArrayAsync();

            return _mapper.Map<UnsentMessageResponse[]>(UnsentMessages);
        }
    }
}
