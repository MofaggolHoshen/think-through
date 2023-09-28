using Microsoft.AspNetCore.Mvc;

namespace BufferDinner.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController
{
    [HttpGet]
    public string Get()
    {
        return "Hello World!";
    }
}