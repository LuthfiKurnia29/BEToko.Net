using domain.entity;
using MediatR;

namespace application.features.category.command.addCategory;

public class AddCategoryCommand : IRequest<Kategori>
{
    public string NamaKategori { get; set; }
}