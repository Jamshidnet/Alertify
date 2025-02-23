using Alertify.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Application.UseCases.Organizations.Queries.GetAllOrganizations
{
    public record GetAllOrganizationsQuery : IRequest<OrganizationResponse[]>;

    public class GetAllOrganizationsQueryHandler : IRequestHandler<GetAllOrganizationsQuery, OrganizationResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllOrganizationsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<OrganizationResponse[]> Handle(GetAllOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var Organizations = await _context.Organizations.ToArrayAsync();

            return _mapper.Map<OrganizationResponse[]>(Organizations);
        }
    }
}
