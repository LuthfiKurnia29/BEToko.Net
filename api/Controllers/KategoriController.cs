using application.features.category.command.addCategory;
using domain.entity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class KategoriController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<Kategori>> AddCategory(AddCategoryCommand command, CancellationToken cancellationToken)
    {
        return await Mediator.Send(command, cancellationToken);
    }
}