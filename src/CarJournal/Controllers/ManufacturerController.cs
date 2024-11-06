using CarJournal.Api.Manufacturer;

using Microsoft.AspNetCore.Mvc;

namespace CarJournal.Controllers;

[ApiController]
[Route("[controller]")]
public class ManufacturerController() : ControllerBase
{
    [HttpPost()]
    public IActionResult CreateManufacturer(CreateManufacturerRequest request)
    {
        return Ok(request);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetManufacturer(int id)
    {
        return Ok(id);
    }

    public IActionResult UpsertManufacturer(int id, UpsertManufacturerRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteManufacturer(int id)
    {
        return Ok(id);
    }
}