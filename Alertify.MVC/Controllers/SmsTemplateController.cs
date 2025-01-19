using Alertify.Application.UseCases.Organizations;
using Alertify.Application.UseCases.Organizations.Queries.GetAllOrganizations;
using Alertify.Application.UseCases.SmsTemplates.Commands.CreateSmsTemplate;
using Alertify.Application.UseCases.SmsTemplates.Commands.DeleteSmsTemplate;
using Alertify.Application.UseCases.SmsTemplates.Commands.UpdateSmsTemplate;
using Alertify.Application.UseCases.SmsTemplates.Queries.GetAllSmsTemplates;
using Alertify.Application.UseCases.SmsTemplates.Queries.GetSmsTemplateById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SmsTemplateController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateSmsTemplate()
        {
            OrganizationResponse[] Organizations = await Mediator.Send(new GetAllOrganizationsQuery());
            ViewData["Organizations"] = Organizations;

            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateSmsTemplate([FromForm] CreateSmsTemplateCommand SmsTemplate)
        {
            await Mediator.Send(SmsTemplate);

            return RedirectToAction("GetAllSmsTemplates");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateSmsTemplateFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllSmsTemplates()
        {
            var SmsTemplates = await Mediator.Send(new GetAllSmsTemplatesQuery());

            return View(SmsTemplates);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateSmsTemplate(int Id)
        {
            var SmsTemplate = await Mediator.Send(new GetSmsTemplateByIdQuery(Id));

            return View(SmsTemplate);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateSmsTemplate([FromForm] UpdateSmsTemplateCommand SmsTemplate)
        {
            await Mediator.Send(SmsTemplate);
            return RedirectToAction("GetAllSmsTemplates");
        }

        public async ValueTask<IActionResult> DeleteSmsTemplate(int Id)
        {
            await Mediator.Send(new DeleteSmsTemplateCommand(Id));

            return RedirectToAction("GetAllSmsTemplates");
        }
    }
}
