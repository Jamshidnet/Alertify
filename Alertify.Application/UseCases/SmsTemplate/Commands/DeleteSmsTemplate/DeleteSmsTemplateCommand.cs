using Alertify.Application.Common.Exceptions;
using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using MediatR;

namespace Alertify.Application.UseCases.SmsTemplates.Commands.DeleteSmsTemplate
{
    public record DeleteSmsTemplateCommand(int Id) : IRequest;
    public class DeleteSmsTemplateCommandHandler : IRequestHandler<DeleteSmsTemplateCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSmsTemplateCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteSmsTemplateCommand request, CancellationToken cancellationToken)
        {
            SmsTemplate? SmsTemplate = await _context.SmsTemplates.FindAsync(request.Id, cancellationToken);

            if (SmsTemplate is null)
                throw new NotFoundException(nameof(SmsTemplate), request.Id);

            _context.SmsTemplates.Remove(SmsTemplate);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
