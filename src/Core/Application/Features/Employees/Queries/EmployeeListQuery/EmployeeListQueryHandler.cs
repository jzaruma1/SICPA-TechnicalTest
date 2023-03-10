using Application.Dtos;
using Application.Helpers;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Employees.Queries.EmployeeListQuery
{
    public class EmployeeListQueryHandler : IRequestHandler<EmployeeListQuery, PagedResponseDto<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeListQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<PagedResponseDto<EmployeeDto>> Handle(EmployeeListQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAll();
            return await employees.GetPagedAsync(request.parameter.PageNumber, request.parameter.PageSize);
        }
    }
}
