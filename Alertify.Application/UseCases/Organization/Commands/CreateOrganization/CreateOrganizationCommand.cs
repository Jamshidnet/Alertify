using Alertify.Application.Common.Interfaces;
using Alertify.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Alertify.Application.UseCases.Organizations.Commands.CreateOrganization
{

    public class CreateOrganizationCommand : IRequest<int>
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string? Inn { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int RegionId { get; set; }
        public int DistrictId { get; set; }
        public int OrganizationClassificationId { get; set; }
    }

    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateOrganizationCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            Organization product = _mapper.Map<Organization>(request);
            await _context.Organizations.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
