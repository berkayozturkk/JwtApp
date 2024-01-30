using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Command;

public class CreateCategoryCommandRequest : IRequest<Result>
{
    public string Name { get; set; }
}
