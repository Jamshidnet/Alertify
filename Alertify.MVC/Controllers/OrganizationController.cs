using Alertify.Application.UseCases.Districts;
using Alertify.Application.UseCases.Districts.Queries.GetAllDistricts;
using Alertify.Application.UseCases.OrganizationClassifications;
using Alertify.Application.UseCases.OrganizationClassifications.Queries.GetAllOrganizationClassifications;
using Alertify.Application.UseCases.Organizations.Commands.CreateOrganization;
using Alertify.Application.UseCases.Organizations.Commands.DeleteOrganization;
using Alertify.Application.UseCases.Organizations.Commands.UpdateOrganization;
using Alertify.Application.UseCases.Organizations.Queries.GetAllOrganizations;
using Alertify.Application.UseCases.Organizations.Queries.GetOrganizationById;
using Alertify.Application.UseCases.Regions;
using Alertify.Application.UseCases.Regions.Queries.GetAllRegions;
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
            RegionResponse[] regions = await Mediator.Send(new GetAllRegionsQuery());
            ViewData["Regions"] = regions;

            DistrictResponse[] districts = await Mediator.Send(new GetAllDistrictsQuery());
            ViewData["Districts"] = districts;

            OrganizationClassificationResponse[] organizationClassifications = await Mediator.Send(new GetAllOrganizationClassificationsQuery());
            ViewData["OrganizationClassifications"] = organizationClassifications;

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
