using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Command;

public class UpdateCategoryCommandRequest : IRequest<Result>
{
    public string Id { get; set; }
    public string Name { get; set; }
}
