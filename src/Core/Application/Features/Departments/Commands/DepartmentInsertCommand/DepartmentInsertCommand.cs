using Application.Dtos;
using MediatR;

namespace Application.Features.Departments.Commands.DepartmentInsertCommand
{
    public class DepartmentInsertCommand : IRequest<bool>
    {
        public DepartmentDto department;
        public DepartmentInsertCommand(DepartmentDto departmentParam)
        {
            department = departmentParam;
        }
    }
}
