using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Departments.Commands.DepartmentInsertCommand
{
    public class DepartmentInsertCommandHandler : IRequestHandler<DepartmentInsertCommand, bool>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentInsertCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<bool> Handle(DepartmentInsertCommand request, CancellationToken cancellationToken)
        {
            var execute = _departmentRepository.Insert(request.department);
            execute.Wait();
            return execute.Result;
        }
    }
}
