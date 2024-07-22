namespace Hogwarts.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Demo")]
public class DemoController : ControllerBase
{
    [HttpGet("welcome")]
    public string GetWelcome()
    {
        return "Welcome to .NET 8!";
    }
}