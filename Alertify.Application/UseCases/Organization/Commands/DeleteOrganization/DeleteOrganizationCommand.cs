using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using MediatR;

namespace Alertify.Application.UseCases.Organizations.Commands.DeleteOrganization
{
    public record DeleteOrganizationCommand(int Id) : IRequest;
    public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOrganizationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            Organization? Organization = await _context.Organizations.FindAsync(request.Id, cancellationToken);

            if (Organization is null)
                throw new NotFoundException(nameof(Organization), request.Id);

            _context.Organizations.Remove(Organization);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
