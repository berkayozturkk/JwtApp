using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Enums;
using JwtApp.Core.Application.Features.CQRS.Command;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers;

public class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommandRequest, Result>
{
    private readonly IRepository<AppUser> _repository;

    public RegisterUserCommandHandler(IRepository<AppUser> repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser newUser = new(
            Guid.NewGuid().ToString(),            //Id
            request.Username,                     //Username
            request.Password,                     //Password
            ((int)RoleType.Member).ToString());   //RoleId

        await _repository.CreateAsync(newUser);

        return new Result(true);
    }
}
