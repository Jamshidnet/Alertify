using AutoMapper;
using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Application.UseCases.OrganizationClassifications;
using Alertify.Domain.Entities;
using MediatR;

namespace Alertify.Application.UseCases.OrganizationClassifications.Queries.GetOrganizationClassificationById
{
    public record GetOrganizationClassificationByIdQuery(int Id) : IRequest<OrganizationClassificationResponse>;

    public class GetOrganizationClassificationByIdQueryHandler : IRequestHandler<GetOrganizationClassificationByIdQuery, OrganizationClassificationResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetOrganizationClassificationByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrganizationClassificationResponse> Handle(GetOrganizationClassificationByIdQuery request, CancellationToken cancellationToken)
        {
            var OrganizationClassification = FilterIfOrganizationClassificationExsists(request.Id);

            var result = _mapper.Map<OrganizationClassificationResponse>(OrganizationClassification);
            return await Task.FromResult(result);
        }

        private OrganizationClassification FilterIfOrganizationClassificationExsists(int id)
            => _dbContext.OrganizationClassifications
                .Find(id) ?? throw new NotFoundException(
                    " There is no OrganizationClassification with this Id. ");
    }
}
