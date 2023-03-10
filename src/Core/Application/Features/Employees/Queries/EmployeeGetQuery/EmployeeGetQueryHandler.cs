using Application.Dtos;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Employees.Queries.EmployeeGetQuery
{
    public class EmployeeGetQueryHandler : IRequestHandler<EmployeeGetQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentEmployeeRepository _departmentEmployeeRepository;

        public EmployeeGetQueryHandler(IEmployeeRepository employeeRepository,
            IDepartmentEmployeeRepository departmentEmployeeRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentEmployeeRepository = departmentEmployeeRepository;
        }

        public async Task<EmployeeDto> Handle(EmployeeGetQuery request, CancellationToken cancellationToken)
        {
            var execute = _employeeRepository.Get(request.employeeId);
            execute.Wait();

            var relations = _departmentEmployeeRepository.ListByEmployee(request.employeeId);
            relations.Wait();

            execute.Result.Departments = relations.Result.Select(x => x.DepartmentId).ToList();
            return execute.Result;
        }
    }
}
