using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Queries;

public class GetCategoryQueryRequest : IRequest<CategoryDto>
{
    public string Id { get; set; }
}
