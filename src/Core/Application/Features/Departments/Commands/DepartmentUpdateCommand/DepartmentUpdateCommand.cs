using Application.Dtos;
using MediatR;

namespace Application.Features.Departments.Commands.DepartmentUpdateCommand
{
    public class DepartmentUpdateCommand : IRequest<bool>
    {
        public DepartmentDto department;
        public int departmentId;

        public DepartmentUpdateCommand(DepartmentDto departmentParam, int idParam)
        {
            department = departmentParam;
            departmentId = idParam;
        }
    }
}
