using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.MessageLogs.Commands.CreateMessageLog
{

    public class CreateMessageLogCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int TemplateId { get; set; }
        public int OrganizationId { get; set; }
        public string RecieverPhoneNumber { get; set; }
        public string? RecieverFullName { get; set; }
    }

    public class CreateMessageLogCommandHandler : IRequestHandler<CreateMessageLogCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateMessageLogCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateMessageLogCommand request, CancellationToken cancellationToken)
        {
            MessageLog product = _mapper.Map<MessageLog>(request);
            await _context.MessageLogs.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
