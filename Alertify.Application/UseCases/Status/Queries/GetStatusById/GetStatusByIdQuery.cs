using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.Statuss.Queries.GetStatusById
{
    public record GetStatusByIdQuery(int Id) : IRequest<StatusResponse>;

    public class GetStatusByIdQueryHandler : IRequestHandler<GetStatusByIdQuery, StatusResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetStatusByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<StatusResponse> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var Status = FilterIfStatusExsists(request.Id);

            var result = _mapper.Map<StatusResponse>(Status);
            return await Task.FromResult(result);
        }

        private Status FilterIfStatusExsists(int id)
            => _dbContext.Statuses
                .Find(id) ?? throw new NotFoundException(
                    " There is no Status with this Id. ");
    }
}
