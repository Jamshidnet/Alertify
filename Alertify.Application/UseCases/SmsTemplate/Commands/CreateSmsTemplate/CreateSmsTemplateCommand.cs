using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.SmsTemplates.Commands.CreateSmsTemplate
{

    public class CreateSmsTemplateCommand : IRequest<int>
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public int OrganizationId { get; set; }
        public long TemplateId { get; set; }
    }

    public class CreateSmsTemplateCommandHandler : IRequestHandler<CreateSmsTemplateCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateSmsTemplateCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateSmsTemplateCommand request, CancellationToken cancellationToken)
        {
            SmsTemplate product = _mapper.Map<SmsTemplate>(request);
            await _context.SmsTemplates.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
