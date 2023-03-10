using Application.Dtos;
using Application.Features.Employees.Commands.EmployeeInsertCommand;
using Application.Features.Employees.Commands.EmployeeUpdateCommand;
using Application.Features.Employees.Queries.EmployeeGetQuery;
using Application.Features.Employees.Queries.EmployeeListQuery;
using Application.Parameters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
           [FromQuery] int size = 10,
           [FromQuery] int page = 1)
        {
            return Ok(_mediator.Send(new EmployeeListQuery(new RequestParameter() { PageSize = size, PageNumber = page })));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mediator.Send(new EmployeeGetQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] EmployeeDto employee)
        {
            return Ok(_mediator.Send(new EmployeeInsertCommand(employee)));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EmployeeDto employee)
        {
            return Ok(_mediator.Send(new EmployeeUpdateCommand(employee, id)));
        }
    }
}
