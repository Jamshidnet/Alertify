using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.SmsTemplates.Commands.UpdateSmsTemplate
{
    public class UpdateSmsTemplateCommand : IRequest
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public int OrganizationId { get; set; }
    }

    public class UpdateSmsTemplateCommandHandler : IRequestHandler<UpdateSmsTemplateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateSmsTemplateCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateSmsTemplateCommand request, CancellationToken cancellationToken)
        {
            SmsTemplate? product = await _context.SmsTemplates.FindAsync(request.Id);
            _mapper.Map(request, product);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
