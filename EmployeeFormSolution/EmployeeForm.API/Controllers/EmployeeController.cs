
using EmployeeForm.Application.Features.Employee.Command.CreateEmployee;
using EmployeeForm.Application.Features.Employee.Command.DeleteEmployee;
using EmployeeForm.Application.Features.Employee.Command.UpdateEmployee;
using EmployeeForm.Application.Features.Employee.Queries.GetAllEmployee;
using EmployeeForm.Application.Features.Employee.Queries.GetEmployeeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeFormAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(  IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Retrieves a list of all employees.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
        {
            // Use MediatR to send a query to get all employees and return them as an HTTP 200 (OK) response.
            var employees = await _mediator.Send(new GetEmployeeQuery());
            return Ok(employees);
        }

        /// <summary>
        /// Retrieves employee details by their ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetailsDto>> Get(int id)
        {
            // Use MediatR to send a query to get employee details by ID and return them as an HTTP 200 (OK) response.
            var leaveType = await _mediator.Send(new GetEmployeeDetailsQuery(id));
            return Ok(leaveType);
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CreateEmployeeCommand>> Post(CreateEmployeeCommand employee)
        {
            // Use MediatR to send a command to create a new employee and return a CreatedAtAction response with the created employee's ID.
            var createdEmployee = await _mediator.Send(employee);
            return CreatedAtAction(nameof(Get), new { id = createdEmployee });

        }

        /// <summary>
        /// Updates an existing employee by their ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateEmployeeCommand employee)
        {
            // Check if the provided ID matches the employee's ID. If not, return a Bad Request response.
            if (id != employee.Id)
            {
                return BadRequest();
            }
            // Use MediatR to send a command to update the employee and return a NoContent response if successful.
            await _mediator.Send(employee);
            return NoContent();
        }

        /// <summary>
        /// Deletes an employee by their ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Create a delete command with the employee's ID and use MediatR to send it for deletion. Return a NoContent response if successful.
            var command = new DeleteEmployeeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
