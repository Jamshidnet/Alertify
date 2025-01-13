using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Alertify.Application.UseCases.UnsentMessages.Commands.CreateUnsentMessage
{

    public class CreateUnsentMessageCommand : IRequest<int>
    {
        public int SmsManagerId { get; set; }
        public string? ErrorMessage { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CreateUnsentMessageCommandHandler : IRequestHandler<CreateUnsentMessageCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateUnsentMessageCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateUnsentMessageCommand request, CancellationToken cancellationToken)
        {
            UnsentMessage product = _mapper.Map<UnsentMessage>(request);
            await _context.UnsentMessages.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
