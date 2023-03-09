using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Departments.Commands.DepartmentUpdateCommand
{
    public class DepartmentUpdateCommandHandler : IRequestHandler<DepartmentUpdateCommand, bool>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentUpdateCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<bool> Handle(DepartmentUpdateCommand request, CancellationToken cancellationToken)
        {
            var execute = _departmentRepository.Update(request.department);
            execute.Wait();
            return execute.Result;
        }
    }
}
