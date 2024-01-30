using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Command;

public class CreateProductCommandRequest : IRequest<Result>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string CategoryId { get; set; }
}
