using Alertify.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Application.UseCases.Districts.Queries.GetAllDistricts
{
    public record GetAllDistrictsQuery : IRequest<DistrictResponse[]>;

    public class GetAllDistrictsQueryHandler : IRequestHandler<GetAllDistrictsQuery, DistrictResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllDistrictsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<DistrictResponse[]> Handle(GetAllDistrictsQuery request, CancellationToken cancellationToken)
        {
            var Districts = await _context.Districts.ToArrayAsync();

            return _mapper.Map<DistrictResponse[]>(Districts);
        }
    }
}
