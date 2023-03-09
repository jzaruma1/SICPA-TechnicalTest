using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Employees.Commands.EmployeeUpdateCommand
{
    public class EmployeeUpdateCommandHandler : IRequestHandler<EmployeeUpdateCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeUpdateCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var execute = _employeeRepository.Update(request.employee);
            execute.Wait();
            return execute.Result;
        }
    }
}
