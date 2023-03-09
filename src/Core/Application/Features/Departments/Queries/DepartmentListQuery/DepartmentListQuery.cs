using Application.Dtos;
using Application.Parameters;
using MediatR;

namespace Application.Features.Departments.Queries.DepartmentListQuery
{
    public class DepartmentListQuery: IRequest<PagedResponseDto<DepartmentDto>>
    {
        public RequestParameter parameter;
        public DepartmentListQuery(RequestParameter parameterParams)
        {
            parameter = parameterParams;
        }
    }
}
