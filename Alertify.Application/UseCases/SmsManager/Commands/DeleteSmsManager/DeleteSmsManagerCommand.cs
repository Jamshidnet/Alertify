using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using MediatR;

namespace Alertify.Application.UseCases.SmsManagers.Commands.DeleteSmsManager
{
    public record DeleteSmsManagerCommand(int Id) : IRequest;
    public class DeleteSmsManagerCommandHandler : IRequestHandler<DeleteSmsManagerCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSmsManagerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteSmsManagerCommand request, CancellationToken cancellationToken)
        {
            SmsManager? SmsManager = await _context.SmsManagers.FindAsync(request.Id, cancellationToken);

            if (SmsManager is null)
                throw new NotFoundException(nameof(SmsManager), request.Id);

            _context.SmsManagers.Remove(SmsManager);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
