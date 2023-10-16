using HRP.Module.HumanResources.API.Database;
using HRP.Module.HumanResources.API.Event;
using HRP.Module.HumanResources.API.Model;
using HRP.Shared.Event;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRP.Module.HumanResources.API.Controllers;

[ApiController]
[Route("/api/human-resources/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository repository;
    private readonly IEventPublisher eventPublisher;

    public EmployeeController(IEmployeeRepository repository, IEventPublisher eventPublisher)
    {
        this.repository = repository;
        this.eventPublisher = eventPublisher;
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType<IEnumerable<Employee>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllAsync()
    {
        var employees = await repository.GetAllAsync();

        return Ok(employees);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType<Employee>(StatusCodes.Status200OK)]
    public async Task<ActionResult<Employee>> GetByIdAsync(int id)
    {
        var employee = await repository.GetByIdAsync(id);

        return Ok(employee);
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType<Employee>(StatusCodes.Status201Created)]
    public async Task<ActionResult<Employee>> CreateAsync(Employee employee)
    {
        await repository.AddAsync(employee);

        await eventPublisher.PublishAsync(new NewEmployeeAdded(employee.Id));

        return StatusCode(StatusCodes.Status201Created, employee);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateAsync(int id, Employee employee)
    {
        var employeeToUpdate = await repository.GetByIdAsync(id);

        if (employeeToUpdate is null) {
            return NotFound();
        }

        employeeToUpdate.Update(employee);
        await repository.UpdateAsync(employeeToUpdate);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);

        return NoContent();
    }
}
