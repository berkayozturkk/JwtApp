using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Command;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, Result>
{
    private readonly IRepository<Category> _repository;

    public DeleteCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var deletedEntity = await _repository.GetByIdAsync(request.Id);

        if (deletedEntity is null)
            throw new ArgumentNullException(nameof(deletedEntity) + "is not found");

        await _repository.RemoveAsync(deletedEntity);
        return new Result(true);
    }
}
