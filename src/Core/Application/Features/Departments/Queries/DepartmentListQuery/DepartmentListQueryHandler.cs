using Application.Dtos;
using Application.Helpers;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Departments.Queries.DepartmentListQuery
{
    public class DepartmentListQueryHandler : IRequestHandler<DepartmentListQuery, PagedResponseDto<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentListQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<PagedResponseDto<DepartmentDto>> Handle(DepartmentListQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAll();
            return await departments.GetPagedAsync(request.parameter.PageNumber, request.parameter.PageSize);
        }
    }
}
