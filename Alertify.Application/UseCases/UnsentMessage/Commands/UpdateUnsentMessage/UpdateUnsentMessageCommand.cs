using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.UnsentMessages.Commands.UpdateUnsentMessage
{
    public class UpdateUnsentMessageCommand : IRequest
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int SmsManagerId { get; set; }
        public string PhoneNumber { get; set; }

    }

    public class UpdateUnsentMessageCommandHandler : IRequestHandler<UpdateUnsentMessageCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateUnsentMessageCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateUnsentMessageCommand request, CancellationToken cancellationToken)
        {
            UnsentMessage? product = await _context.UnsentMessages.FindAsync(request.Id);
            _mapper.Map(request, product);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
