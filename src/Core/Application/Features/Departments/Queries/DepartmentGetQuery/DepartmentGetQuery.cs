using Application.Dtos;
using MediatR;

namespace Application.Features.Departments.Queries.DepartmentGetQuery
{
    public class DepartmentGetQuery : IRequest<DepartmentDto>
    {
        public int departmentId;
        public DepartmentGetQuery(int idParam)
        {
            departmentId = idParam;
        }
    }
}
