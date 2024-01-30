using JwtApp.Core.Application.Dto;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Command;

public class RegisterUserCommandRequest :IRequest<Result>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
