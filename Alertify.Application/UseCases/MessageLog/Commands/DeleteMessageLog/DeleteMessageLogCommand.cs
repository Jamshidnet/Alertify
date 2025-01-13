using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using MediatR;

namespace Alertify.Application.UseCases.MessageLogs.Commands.DeleteMessageLog
{
    public record DeleteMessageLogCommand(int Id) : IRequest;
    public class DeleteMessageLogCommandHandler : IRequestHandler<DeleteMessageLogCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMessageLogCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteMessageLogCommand request, CancellationToken cancellationToken)
        {
            MessageLog? MessageLog = await _context.MessageLogs.FindAsync(request.Id, cancellationToken);

            if (MessageLog is null)
                throw new NotFoundException(nameof(MessageLog), request.Id);

            _context.MessageLogs.Remove(MessageLog);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
