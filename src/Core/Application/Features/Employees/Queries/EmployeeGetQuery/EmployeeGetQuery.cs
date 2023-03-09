using Application.Dtos;
using MediatR;

namespace Application.Features.Employees.Queries.EmployeeGetQuery
{
    public class EmployeeGetQuery : IRequest<EmployeeDto>
    {
        public int employeeId;
        public EmployeeGetQuery(int idParam)
        {
            employeeId = idParam;
        }
    }
}
