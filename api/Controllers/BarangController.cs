using domain.entity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BarangController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<Barang>>> GetBarang()
    {
        return Ok();
    }
    
    
}