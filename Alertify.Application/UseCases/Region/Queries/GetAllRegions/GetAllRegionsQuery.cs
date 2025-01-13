using AutoMapper;
using Alertify.Application.Common.Interfaces;
using Alertify.Application.UseCases.Regions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Application.UseCases.Regions.Queries.GetAllRegions
{
    public record GetAllRegionsQuery : IRequest<RegionResponse[]>;

    public class GetAllRegionsQueryHandler : IRequestHandler<GetAllRegionsQuery, RegionResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllRegionsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<RegionResponse[]> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
        {
            var Regions = await _context.Regions.ToArrayAsync();

            return _mapper.Map<RegionResponse[]>(Regions);
        }
    }
}
