using Alertify.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Application.UseCases.SmsManagers.Queries.GetAllSmsManagers
{
    public record GetAllSmsManagersQuery : IRequest<SmsManagerResponse[]>;

    public class GetAllSmsManagersQueryHandler : IRequestHandler<GetAllSmsManagersQuery, SmsManagerResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllSmsManagersQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<SmsManagerResponse[]> Handle(GetAllSmsManagersQuery request, CancellationToken cancellationToken)
        {
            var SmsManagers = await _context.SmsManagers.ToArrayAsync();

            return _mapper.Map<SmsManagerResponse[]>(SmsManagers);
        }
    }
}
