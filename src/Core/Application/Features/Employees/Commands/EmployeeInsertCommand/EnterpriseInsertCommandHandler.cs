using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Employees.Commands.EmployeeInsertCommand
{
    public class EmployeeInsertCommandHandler : IRequestHandler<EmployeeInsertCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeInsertCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<bool> Handle(EmployeeInsertCommand request, CancellationToken cancellationToken)
        {
            var execute = _employeeRepository.Insert(request.employee);
            execute.Wait();
            return execute.Result;
        }
    }
}
