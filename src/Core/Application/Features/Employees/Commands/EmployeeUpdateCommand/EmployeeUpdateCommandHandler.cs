using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Employees.Commands.EmployeeUpdateCommand
{
    public class EmployeeUpdateCommandHandler : IRequestHandler<EmployeeUpdateCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentEmployeeRepository _departmentEmployeeRepository;
        public EmployeeUpdateCommandHandler(IEmployeeRepository employeeRepository,
            IDepartmentEmployeeRepository departmentEmployeeRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentEmployeeRepository = departmentEmployeeRepository;
        }

        public async Task<bool> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var execute = _employeeRepository.Update(request.employee);
            execute.Wait();
            var requestRelation = _departmentEmployeeRepository.AddOrUpdateRelations(request.employeeId, request.employee.Departments);
            requestRelation.Wait();

            return execute.Result;
        }
    }
}
