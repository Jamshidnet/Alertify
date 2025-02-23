using Alertify.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alertify.Application.UseCases.OrganizationClassifications.Queries.GetAllOrganizationClassifications
{
    public record GetAllOrganizationClassificationsQuery : IRequest<OrganizationClassificationResponse[]>;

    public class GetAllOrganizationClassificationsQueryHandler : IRequestHandler<GetAllOrganizationClassificationsQuery, OrganizationClassificationResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllOrganizationClassificationsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<OrganizationClassificationResponse[]> Handle(GetAllOrganizationClassificationsQuery request, CancellationToken cancellationToken)
        {
            var OrganizationClassifications = await _context.OrganizationClassifications.ToArrayAsync();

            return _mapper.Map<OrganizationClassificationResponse[]>(OrganizationClassifications);
        }
    }
}
