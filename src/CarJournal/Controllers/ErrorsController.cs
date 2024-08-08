using Microsoft.AspNetCore.Mvc;

namespace CarJournal.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    protected IActionResult Error()
    {
        return Problem();
    }
}