using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IQueryable<EmployeeDto>> GetAll();
        Task<EmployeeDto> Get(int id);
        Task<Employee> GetEntity(int id);
        Task<bool> Insert(EmployeeDto employee);
        Task<bool> Update(EmployeeDto employee);
    }
}
