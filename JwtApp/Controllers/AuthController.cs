using JwtApp.Core.Application.Features.CQRS.Command;
using JwtApp.Core.Application.Features.CQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtApp.Controllers;

public class AuthController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterUserAsync(RegisterUserCommandRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> LoginUserAsync(CheckUserQueryRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}
