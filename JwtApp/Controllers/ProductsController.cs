using JwtApp.Core.Application.Features.CQRS.Command;
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync([FromQuery] DeleteProductCommandRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductAsync([FromQuery] CreateProductCommandRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync([FromQuery] UpdateProductCommandRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}
