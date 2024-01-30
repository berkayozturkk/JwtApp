using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Command;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, Result>
{
    private readonly IRepository<Category> _repository;

    public UpdateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        Category category = await _repository.GetByIdAsync(request.Id);

        if (category is null)
            new ArgumentNullException(nameof(category) + "is not found");

        category.Name = request.Name;

        await _repository.UpdateAsync(category);
        return new Result(true);
    }
}

