using JwtApp.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JwtApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : Controller
{
    //public readonly IMediator _mediator;

    //public BaseController(IMediator mediator)
    //{
    //    _mediator = mediator;
    //}
    private IMediator? _mediator;
    protected IMediator? Mediator => _mediator ??=
        HttpContext.RequestServices.GetService<IMediator>();
}
