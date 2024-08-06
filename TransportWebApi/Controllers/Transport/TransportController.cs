using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Transport;

[Route("api")]
[ApiController]
public class TransportController : Controller
{
    /// <summary>
    /// Get IEnumerable of Car by id
    /// </summary>
    /// <param name="id">Id of Car collection</param>
    /// <returns></returns>
    [HttpGet]
    [Route("get_info", Name = "GetInfo")]
    [Produces("application/json")]
    public IActionResult GetInfo([FromQuery] string? id)
    {
        return Ok(id);
    }

    /// <summary>
    /// Get IEnumerable of Car by date
    /// </summary>
    /// <param name="date">The date of Car data</param>
    /// <returns></returns>
    [HttpGet("GetCars/{date:datetime}", Name = "GetCarsFromDate")]
    [Produces("application/json")]
    public async Task<IActionResult> GetCarsFromDate(DateTime date)
    {
        return Json(new { Name = "hello there", Date = date });
    }
}
