using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.Districts.Queries.GetDistrictById
{
    public record GetDistrictByIdQuery(int Id) : IRequest<DistrictResponse>;

    public class GetDistrictByIdQueryHandler : IRequestHandler<GetDistrictByIdQuery, DistrictResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetDistrictByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DistrictResponse> Handle(GetDistrictByIdQuery request, CancellationToken cancellationToken)
        {
            var District = FilterIfDistrictExsists(request.Id);

            var result = _mapper.Map<DistrictResponse>(District);
            return await Task.FromResult(result);
        }

        private District FilterIfDistrictExsists(int id)
            => _dbContext.Districts
                .Find(id) ?? throw new NotFoundException(
                    " There is no District with this Id. ");
    }
}
