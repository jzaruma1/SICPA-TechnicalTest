using Application.Dtos;
using MediatR;

namespace Application.Features.Employees.Commands.EmployeeUpdateCommand
{
    public class EmployeeUpdateCommand : IRequest<bool>
    {
        public EmployeeDto employee;
        public int employeeId;
        public EmployeeUpdateCommand(EmployeeDto employeeParam, int idParam)
        {
            employee = employeeParam;
            employeeId = idParam;
        }
    }
}
