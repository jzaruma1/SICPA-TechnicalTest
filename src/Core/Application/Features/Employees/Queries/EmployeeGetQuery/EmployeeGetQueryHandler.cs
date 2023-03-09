using Application.Dtos;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Employees.Queries.EmployeeGetQuery
{
    public class EmployeeGetQueryHandler : IRequestHandler<EmployeeGetQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeGetQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDto> Handle(EmployeeGetQuery request, CancellationToken cancellationToken)
        {
            var execute = _employeeRepository.Get(request.employeeId);
            execute.Wait();
            return execute.Result;
        }
    }
}
