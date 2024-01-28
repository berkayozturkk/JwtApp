using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Command;

public class DeleteProductCommandRequest : IRequest<Result>
{
    public string Id { get; set; }
}
