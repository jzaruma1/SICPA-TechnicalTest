using Application.Dtos;
using Application.Features.Departments.Commands.DepartmentInsertCommand;
using Application.Features.Departments.Commands.DepartmentUpdateCommand;
using Application.Features.Departments.Queries.DepartmentGetQuery;
using Application.Features.Departments.Queries.DepartmentListQuery;
using Application.Parameters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] int size = 10,
            [FromQuery] int page = 1)
        {
            return Ok(_mediator.Send(new DepartmentListQuery(new RequestParameter() { PageSize = size, PageNumber = page })));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mediator.Send(new DepartmentGetQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DepartmentDto department)
        {
            return Ok(_mediator.Send(new DepartmentInsertCommand(department)));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, DepartmentDto department)
        {
            return Ok(_mediator.Send(new DepartmentUpdateCommand(department, id)));
        }

    }
}
