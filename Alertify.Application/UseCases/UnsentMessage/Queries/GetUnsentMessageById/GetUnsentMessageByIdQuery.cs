using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.UnsentMessages.Queries.GetUnsentMessageById
{
    public record GetUnsentMessageByIdQuery(int Id) : IRequest<UnsentMessageResponse>;

    public class GetUnsentMessageByIdQueryHandler : IRequestHandler<GetUnsentMessageByIdQuery, UnsentMessageResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetUnsentMessageByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UnsentMessageResponse> Handle(GetUnsentMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var UnsentMessage = FilterIfUnsentMessageExsists(request.Id);

            var result = _mapper.Map<UnsentMessageResponse>(UnsentMessage);
            return await Task.FromResult(result);
        }

        private UnsentMessage FilterIfUnsentMessageExsists(int id)
            => _dbContext.UnsentMessages
                .Find(id) ?? throw new NotFoundException(
                    " There is no UnsentMessage with this Id. ");
    }
}
