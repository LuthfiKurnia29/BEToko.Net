using application.features.category.command.addCategory;
using application.features.category.queries.getAllCategory;
using domain.entity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class KategoriController : BaseController
{
    /// <summary>
    /// Add Category
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Kategori>> AddCategory(AddCategoryCommand command, CancellationToken cancellationToken)
    {
        return await Mediator.Send(command, cancellationToken);
    }

    [HttpGet]
    public async Task<ActionResult<List<Kategori>>> GetAllCategory(CancellationToken cancellationToken)
    {
        return await Mediator.Send(new GetAllCategoryQuery(), cancellationToken);
    }
}