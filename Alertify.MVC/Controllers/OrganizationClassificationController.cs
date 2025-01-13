using Alertify.Application.UseCases.OrganizationClassifications.Queries.GetAllOrganizationClassifications;
using Alertify.Application.UseCases.OrganizationClassifications.Queries.GetOrganizationClassificationById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrganizationClassificationController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateOrganizationClassification()
        {
            return View();
        }


        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateOrganizationClassificationFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllOrganizationClassifications()
        {
            var OrganizationClassifications = await Mediator.Send(new GetAllOrganizationClassificationsQuery());

            return View(OrganizationClassifications);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateOrganizationClassification(int Id)
        {
            var OrganizationClassification = await Mediator.Send(new GetOrganizationClassificationByIdQuery(Id));

            return View(OrganizationClassification);
        }
    }
}
