using application.features.barang.command.addBarangs;
using application.features.barang.Queries.All;
using domain.entity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BarangController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<Barang>>> GetBarang(CancellationToken cancellationToken)
    {
        return await Mediator.Send(new GetAllBarangQuery(), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<Barang>> AddBarang(AddBarangCommand command, CancellationToken cancellationToken)
    {
        return await Mediator.Send(command, cancellationToken);
    }
    
}