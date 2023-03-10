using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IDepartmentEmployeeRepository
    {
        Task<IQueryable<DepartmentEmployee>> ListByEmployee(int employeeId);
        Task AddOrUpdateRelations(int employeeId, List<int> departments);
    }
}
