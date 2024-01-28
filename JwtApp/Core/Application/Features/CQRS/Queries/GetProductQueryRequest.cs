using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Queries;

public class GetProductQueryRequest : IRequest<ProductDto>
{
    public string Id { get; set; }
}
