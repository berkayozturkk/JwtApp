using JwtApp.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JwtApp.Controllers;

public class ProductsController : BaseController
{
    //public ProductsController(IMediator mediator) : base(mediator){}

    [HttpGet]
    public async Task<IActionResult> GetProductListAsync()
    {
        var response = await Mediator.Send(new GetAllProductsQueryRequest());
        return Ok(response);
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductAsync([FromQuery] GetProductQueryRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}
