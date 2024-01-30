using JwtApp.Core.Application.Features.CQRS.Command;
using JwtApp.Core.Application.Features.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtApp.Controllers;

public class CategoriesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetProductListAsync()
    {
        var response = await Mediator.Send(new GetAllCategoriesQueryRequest());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductAsync([FromQuery] GetCategoryQueryRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryAsync([FromQuery] DeleteCategoryCommandRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategoryAsync([FromQuery] CreateCategoryCommandRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategoryAsync([FromQuery] UpdateCategoryCommandRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}
