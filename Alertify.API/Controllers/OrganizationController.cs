using Alertify.Application.UseCases.Organizations;
using Alertify.Application.UseCases.Organizations.Commands.CreateOrganization;
using Alertify.Application.UseCases.Organizations.Commands.DeleteOrganization;
using Alertify.Application.UseCases.Organizations.Commands.UpdateOrganization;
using Alertify.Application.UseCases.Organizations.Queries.GetAllOrganizations;
using Alertify.Application.UseCases.Organizations.Queries.GetOrganizationById;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.API.Controllers
{
    /// <summary>
    /// [Authorize(Roles = "Admin")]
    /// </summary>
    public class OrganizationController : ApiBaseController
    {

        [HttpPost("[action]")]
        public async ValueTask<int> CreateOrganization(CreateOrganizationCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<OrganizationResponse> GetOrganizationById(int Id)
        {
            return await Mediator.Send(new GetOrganizationByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<OrganizationResponse>> GetAllOrganizations()
        {
            return await Mediator.Send(new GetAllOrganizationsQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateOrganization(UpdateOrganizationCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteOrganization(DeleteOrganizationCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
