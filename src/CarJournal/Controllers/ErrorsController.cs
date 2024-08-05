using Microsoft.AspNetCore.Mvc;

namespace CarJournal.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}