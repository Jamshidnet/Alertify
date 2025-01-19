using Alertify.Application.UseCases.OrganizationClassifications.Queries.GetAllOrganizationClassifications;
using Alertify.Application.UseCases.Organizations.Queries.GetAllOrganizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrganizationClassificationController : ApiBaseController
    {
       [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllOrganizationClassifications()
        {
            var OrganizationClassifications = await Mediator.Send(new GetAllOrganizationClassificationsQuery());

            return View(OrganizationClassifications);
        }
    }
}
