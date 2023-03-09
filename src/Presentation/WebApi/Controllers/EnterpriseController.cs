using Application.Dtos;
using Application.Features.Enterprises.Commands.EnterpriseInsertCommand;
using Application.Features.Enterprises.Commands.EnterpriseUpdateCommand;
using Application.Features.Enterprises.Queries.EnterpriseGetQuery;
using Application.Features.Enterprises.Queries.EnterpriseListQuery;
using Application.Parameters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnterpriseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EnterpriseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
           [FromQuery] int size = 10,
           [FromQuery] int page = 1)
        {
            return Ok(_mediator.Send(new EnterpriseListQuery(new RequestParameter() { PageSize = size, PageNumber = page })));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mediator.Send(new EnterpriseGetQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] EnterpriseDto enterprise)
        {
            return Ok(_mediator.Send(new EnterpriseInsertCommand(enterprise)));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EnterpriseDto enterprise)
        {
            return Ok(_mediator.Send(new EnterpriseUpdateCommand(enterprise, id)));
        }
    }
}