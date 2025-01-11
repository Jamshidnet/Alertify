using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.SmsManagers.Commands.UpdateSmsManager
{
    public class UpdateSmsManagerCommand : IRequest
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
    }

    public class UpdateSmsManagerCommandHandler : IRequestHandler<UpdateSmsManagerCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateSmsManagerCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateSmsManagerCommand request, CancellationToken cancellationToken)
        {
            SmsManager? product = await _context.SmsManagers.FindAsync(request.Id);
            _mapper.Map(request, product);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
