using AutoMapper;
using JwtApp.Core.Application.Dto;
using JwtApp.Core.Application.Features.CQRS.Queries;
using JwtApp.Core.Application.Interfaces;
using JwtApp.Core.Domain;
using MediatR;

namespace JwtApp.Core.Application.Features.CQRS.Handlers;

public class GetAllCategoriesQueryHandler
    : IRequestHandler<GetAllCategoriesQueryRequest, List<CategoryDto>>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var allCategoryList = await _repository.GetAllAsync();
        return _mapper.Map<List<CategoryDto>>(allCategoryList);
    }
}