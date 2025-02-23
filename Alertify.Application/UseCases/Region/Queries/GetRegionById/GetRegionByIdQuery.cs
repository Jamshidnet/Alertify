using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.Regions.Queries.GetRegionById
{
    public record GetRegionByIdQuery(int Id) : IRequest<RegionResponse>;

    public class GetRegionByIdQueryHandler : IRequestHandler<GetRegionByIdQuery, RegionResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetRegionByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RegionResponse> Handle(GetRegionByIdQuery request, CancellationToken cancellationToken)
        {
            var Region = FilterIfRegionExsists(request.Id);

            var result = _mapper.Map<RegionResponse>(Region);
            return await Task.FromResult(result);
        }

        private Region FilterIfRegionExsists(int id)
            => _dbContext.Regions
                .Find(id) ?? throw new NotFoundException(
                    " There is no Region with this Id. ");
    }
}
