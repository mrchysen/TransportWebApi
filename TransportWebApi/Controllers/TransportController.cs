using Microsoft.AspNetCore.Mvc;

namespace TransportWebApi.Controllers;

[Route("api")]
public class TransportController : Controller
{
    [HttpGet]
    [Route("get_info")]
    public IActionResult GetInfo(string? id)
    {
        return Ok(id);
    } 
}
