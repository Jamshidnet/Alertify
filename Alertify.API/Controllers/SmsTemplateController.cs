using Alertify.Application.UseCases.SmsTemplates.Commands.CreateSmsTemplate;
using Alertify.Application.UseCases.SmsTemplates.Commands.DeleteSmsTemplate;
using Alertify.Application.UseCases.SmsTemplates.Commands.UpdateSmsTemplate;
using Alertify.Application.UseCases.SmsTemplates.Queries.GetAllSmsTemplates;
using Alertify.Application.UseCases.SmsTemplates.Queries.GetSmsTemplateById;
using Alertify.Application.UseCases.SmsTemplates;
using Alertify.Application.UseCases.SmsTemplates.Commands.CreateSmsTemplate;
using Alertify.Application.UseCases.SmsTemplates.Commands.DeleteSmsTemplate;
using Alertify.Application.UseCases.SmsTemplates.Commands.UpdateSmsTemplate;
using Alertify.Application.UseCases.SmsTemplates.Queries.GetAllSmsTemplates;
using Alertify.Application.UseCases.SmsTemplates.Queries.GetSmsTemplateById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.API.Controllers
{
   /// <summary>
   /// [Authorize(Roles = "Admin")]
   /// </summary>
    public class SmsTemplateController : ApiBaseController
    {

        [HttpPost("[action]")]
        public async ValueTask<int> CreateSmsTemplate(CreateSmsTemplateCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<SmsTemplateResponse> GetSmsTemplateById(int Id)
        {
            return await Mediator.Send(new GetSmsTemplateByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<SmsTemplateResponse>> GetAllSmsTemplates()
        {
            return await Mediator.Send(new GetAllSmsTemplatesQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateSmsTemplate(UpdateSmsTemplateCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteSmsTemplate(DeleteSmsTemplateCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
