using application.common.interfaces;
using AutoMapper;
using domain.entity;
using MediatR;

namespace application.features.category.command.addCategory;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Kategori>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Kategori> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Kategori>(request);
        await _categoryRepository.AddCategory(category);
        return category;
    }
}