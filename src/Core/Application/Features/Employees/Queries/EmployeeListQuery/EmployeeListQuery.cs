using Application.Dtos;
using Application.Parameters;
using MediatR;

namespace Application.Features.Employees.Queries.EmployeeListQuery
{
    public class EmployeeListQuery : IRequest<PagedResponseDto<EmployeeDto>>
    {
        public RequestParameter parameter;
        public EmployeeListQuery(RequestParameter parameterParams)
        {
            parameter = parameterParams;
        }
    }
}
