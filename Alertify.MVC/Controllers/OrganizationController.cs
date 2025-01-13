using Alertify.Application.UseCases.Organizations.Commands.CreateOrganization;
using Alertify.Application.UseCases.Organizations.Commands.DeleteOrganization;
using Alertify.Application.UseCases.Organizations.Commands.UpdateOrganization;
using Alertify.Application.UseCases.Organizations.Queries.GetAllOrganizations;
using Alertify.Application.UseCases.Organizations.Queries.GetOrganizationById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrganizationController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateOrganization()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateOrganization([FromForm] CreateOrganizationCommand Organization)
        {
            await Mediator.Send(Organization);

            return RedirectToAction("GetAllOrganizations");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateOrganizationFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllOrganizations()
        {
            var Organizations = await Mediator.Send(new GetAllOrganizationsQuery());

            return View(Organizations);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateOrganization(int Id)
        {
            var Organization = await Mediator.Send(new GetOrganizationByIdQuery(Id));

            return View(Organization);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateOrganization([FromForm] UpdateOrganizationCommand Organization)
        {
            await Mediator.Send(Organization);
            return RedirectToAction("GetAllOrganizations");
        }

        public async ValueTask<IActionResult> DeleteOrganization(int Id)
        {
            await Mediator.Send(new DeleteOrganizationCommand(Id));

            return RedirectToAction("GetAllOrganizations");
        }
    }
}
