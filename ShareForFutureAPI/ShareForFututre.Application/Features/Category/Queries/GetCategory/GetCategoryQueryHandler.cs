namespace ShareForFututre.Application.Features.Category.Queries.GetCategory;
using AutoMapper;
using MediatR;
using ShareForFututre.Application.Contracts.Persistence;
using ShareForFututre.Application.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery,
    DeviceCategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<DeviceCategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category is null)
        {
            throw new ArgumentNullException("Category is not found", nameof(request.Id));
        }

        var categoryDto = _mapper.Map<DeviceCategoryDto>(category);

        return categoryDto;
    }
}

