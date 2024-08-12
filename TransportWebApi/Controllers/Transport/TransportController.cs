using Core.Domains.Cars.Models;
using Core.Domains.Cars.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Transport;

[Route("transport-api")]
[ApiController]
public class TransportController : Controller
{
    public readonly ICarDayInfoRepository Repository;
    private readonly ILogger<TransportController> Logger;
    public TransportController(ICarDayInfoRepository repository, ILogger<TransportController> logger)
    {
        Repository = repository;
        Logger = logger;
    }

    /// <summary>
    /// Get CarDayInfo by id
    /// </summary>
    /// <param name="id">Id of CarDayInfo</param>
    /// <returns></returns>
    [HttpGet("get/{id}", Name = "GetInfo")]
    [Produces("application/json")]
    public async Task<IActionResult> CarDayInfo(string id)
    {
        var result = Guid.TryParse(id, out var carId);

        if (!result)
            return BadRequest();

        var carDayInfo = await Repository.Get(carId);

        if (carDayInfo == null)
            return NotFound(id);

        return Ok(carDayInfo);
    }

    [HttpGet("get-count", Name = "GetCountCarDayInfoGroupByDateTime")]
    public async Task<Dictionary<DateOnly, int>> GetCountCarDayInfoGroupByDateTime()
    {
        Logger.LogInformation("hello from GetCountCarDayInfoGroupByDateTime");

        return await Repository.GetGroupDateTimeCount();
    } 

    /// <summary>
    /// Get IEnumerable of Car by date
    /// </summary>
    /// <param name="date">The date of Car data</param>
    /// <returns></returns>
    [HttpGet("get-by-date/{date:datetime}", Name = "GetCarsFromDate")]
    [Produces("application/json")]
    public async Task<IEnumerable<CarDayInfo>> GetCarsFromDate(DateOnly date)
    {
        var collection = await Repository.Get(date);

        return collection;
    }

    [HttpPut(Name = "UpdateCarDayInfo")]
    public async Task<IActionResult> Update(CarDayInfo carDayInfo)
    {
        var result = await Repository.Update(carDayInfo);

        if (!result) return BadRequest();

        return Ok();
    }

    [HttpDelete("{id}", Name = "DeleteCarDayInfo")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = Guid.TryParse(id, out var carId);

        if (!result)
            return BadRequest();

        return Ok(await Repository.Delete(carId));
    }

    /// <summary>
    /// Create CarDayInfo and return id of created item
    /// </summary>
    /// <param name="carDayInfo"></param>
    /// <returns></returns>
    [HttpPost(Name = "CreateCarDayInfo")]
    public async Task<IActionResult> Create(CarDayInfo carDayInfo)
    {
        var id = await Repository.Create(carDayInfo);
        
        return Ok(id);
    }
}
