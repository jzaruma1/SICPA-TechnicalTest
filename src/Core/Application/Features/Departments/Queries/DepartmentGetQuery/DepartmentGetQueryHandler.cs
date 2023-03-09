using Application.Dtos;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Departments.Queries.DepartmentGetQuery
{
    public class DepartmentGetQueryHandler : IRequestHandler<DepartmentGetQuery, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentGetQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDto> Handle(DepartmentGetQuery request, CancellationToken cancellationToken)
        {
            var execute = _departmentRepository.Get(request.departmentId);
            execute.Wait();
            return execute.Result;
        }
    }
}
