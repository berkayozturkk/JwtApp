using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Queries;

public class GetAllCategoriesQueryRequest : IRequest<List<CategoryDto>>
{
}
