using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Command;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, Result>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        Category newCategory = new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name
        };

        await _repository.CreateAsync(newCategory);
        return new Result(true);
    }
}