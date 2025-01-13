using AutoMapper;
using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Application.UseCases.Organizations;
using Alertify.Domain.Entities;
using MediatR;

namespace Alertify.Application.UseCases.Organizations.Queries.GetOrganizationById
{
    public record GetOrganizationByIdQuery(int Id) : IRequest<OrganizationResponse>;

    public class GetOrganizationByIdQueryHandler : IRequestHandler<GetOrganizationByIdQuery, OrganizationResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetOrganizationByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrganizationResponse> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var Organization = FilterIfOrganizationExsists(request.Id);

            var result = _mapper.Map<OrganizationResponse>(Organization);
            return await Task.FromResult(result);
        }

        private Organization FilterIfOrganizationExsists(int id)
            => _dbContext.Organizations
                .Find(id) ?? throw new NotFoundException(
                    " There is no Organization with this Id. ");
    }
}
