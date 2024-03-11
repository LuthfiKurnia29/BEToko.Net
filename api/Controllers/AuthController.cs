using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.features.auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        [HttpPost("/register")]
        public async Task<ActionResult<string>> Register(RegisterCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }
    }
}