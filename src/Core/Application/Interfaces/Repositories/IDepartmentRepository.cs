using Application.Dtos;

namespace Application.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IQueryable<DepartmentDto>> GetAll();
        Task<DepartmentDto> Get(int id);
        Task<bool> Insert(DepartmentDto department);
        Task<bool> Update(DepartmentDto department);
    }
}
