using application.common.interfaces;
using domain.entity;
using MediatR;

namespace application.features.category.queries.getAllCategory;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<Kategori>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Kategori>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAllCategory();
    }
}