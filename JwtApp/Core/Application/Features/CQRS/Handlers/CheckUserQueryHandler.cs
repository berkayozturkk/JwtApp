using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Queries;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers;

public class CheckUserQueryHandler
    : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
{
    private readonly IRepository<AppUser> _userRepository;
    private readonly IRepository<AppRole> _roleRepository;

    public CheckUserQueryHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByFilterAsync(x =>
             x.UserName == request.Username &&
             x.Password == request.Password);

        if (user is null)
            return new CheckUserResponseDto(false);

        CheckUserResponseDto checkUserResponse =
            new(user.Id, user.UserName, true);

        checkUserResponse.Role = await GetUserRoleDefinition(user.AppRoleId);

        return checkUserResponse;
    }

    private async Task<string> GetUserRoleDefinition(string userRoleId)
    {
        var userRole = await _roleRepository.GetByFilterAsync(x =>x.Id == userRoleId);

        return userRole.Definition;
    }
}
