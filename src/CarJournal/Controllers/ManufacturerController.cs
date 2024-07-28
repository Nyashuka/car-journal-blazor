using CarJournal.Api.Manufacturer;

using Microsoft.AspNetCore.Mvc;

namespace CarJournal.Controllers;

[ApiController]
public class ManufacturerController() : ControllerBase
{
    [HttpPost("manufacturer")]
    public IActionResult CreateManufacturer(CreateManufacturerRequest request)
    {
        return Ok(request);
    }

    [HttpGet("manufacturer/{id:int}")]
    public IActionResult GetManufacturer(int id)
    {
        return Ok(id);   
    }

    [HttpPut("manufacturer/{id:int}")]
    public IActionResult UpsertManufacturer(int id, UpsertManufacturerRequest request)
    {
        return Ok(request);
    }
    
    [HttpDelete("manufacturer/{id:int}")]
    public IActionResult DeleteManufacturer(int id)
    {
        return Ok(id);
    }
}