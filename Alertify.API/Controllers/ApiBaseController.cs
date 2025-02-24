﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Alertify.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    ///[Authorize]
    public class ApiBaseController : Controller
    {
        private IMediator? _mediator;
        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
