using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.SmsManagers.Commands.CreateSmsManager
{

    public class CreateSmsManagerCommand : IRequest<int>
    {
        public int TemplateId { get; set; }
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }
        public int StatusId { get; set; }
    }

    public class CreateSmsManagerCommandHandler : IRequestHandler<CreateSmsManagerCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateSmsManagerCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateSmsManagerCommand request, CancellationToken cancellationToken)
        {
            SmsManager product = _mapper.Map<SmsManager>(request);
            await _context.SmsManagers.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
