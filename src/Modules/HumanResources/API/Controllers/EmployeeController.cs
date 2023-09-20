using Microsoft.AspNetCore.Mvc;

namespace HRP.Module.HumanResources.API;

[ApiController]
[Route("/api/human-resources/[controller]")]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    [Route("list")]
    public ActionResult<IEnumerable<Employee>> GetAll()
    {
        return Ok();
    }
}
