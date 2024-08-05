using Microsoft.AspNetCore.Mvc;

namespace TransportWebApi.Controllers;

[Route("api")]
[ApiController]
public class TransportController : Controller
{
    [HttpGet]
    [Route("get_info")]
    public IActionResult GetInfo([FromQuery] string? id)
    {
        return Ok(id);
    }

    [HttpGet]
    [Route("GetCars/{date:datetime}")]
    public async Task<IActionResult> GetCarsFromDate(DateTime date) 
    {
        return Json(new { Name="hello there", Date=date });
    }
}
