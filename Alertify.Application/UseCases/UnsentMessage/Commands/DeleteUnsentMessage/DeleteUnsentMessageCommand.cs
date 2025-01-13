using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using MediatR;

namespace Alertify.Application.UseCases.UnsentMessages.Commands.DeleteUnsentMessage
{
    public record DeleteUnsentMessageCommand(int Id) : IRequest;
    public class DeleteUnsentMessageCommandHandler : IRequestHandler<DeleteUnsentMessageCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUnsentMessageCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteUnsentMessageCommand request, CancellationToken cancellationToken)
        {
            UnsentMessage? UnsentMessage = await _context.UnsentMessages.FindAsync(request.Id, cancellationToken);

            if (UnsentMessage is null)
                throw new NotFoundException(nameof(UnsentMessage), request.Id);

            _context.UnsentMessages.Remove(UnsentMessage);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
