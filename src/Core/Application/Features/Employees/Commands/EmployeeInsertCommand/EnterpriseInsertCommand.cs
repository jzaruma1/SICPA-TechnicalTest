using Application.Dtos;
using MediatR;

namespace Application.Features.Employees.Commands.EmployeeInsertCommand
{
    public class EmployeeInsertCommand : IRequest<bool>
    {
        public EmployeeDto employee;

        public EmployeeInsertCommand(EmployeeDto employeeParam)
        {
            employee = employeeParam;
        }
    }
}
