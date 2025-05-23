using Microsoft.AspNetCore.Mvc;

public class Affcontroller : ControllerBase
{
    [HttpGet]
    [Route("api/")]
    public IActionResult Get()
    {
        return Ok("Hello World!");
    }
    [HttpGet]
    [Route("api/aff")]
    public IActionResult GetAff()
    {
        return Ok("stuff to put there");
    }
}