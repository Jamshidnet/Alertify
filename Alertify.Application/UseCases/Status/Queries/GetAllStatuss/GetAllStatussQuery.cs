using Alertify.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Application.UseCases.Statuss.Queries.GetAllStatuss
{
    public record GetAllStatussQuery : IRequest<StatusResponse[]>;

    public class GetAllStatussQueryHandler : IRequestHandler<GetAllStatussQuery, StatusResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllStatussQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<StatusResponse[]> Handle(GetAllStatussQuery request, CancellationToken cancellationToken)
        {
            var Statuss = await _context.Statuses.ToArrayAsync();

            return _mapper.Map<StatusResponse[]>(Statuss);
        }
    }
}
