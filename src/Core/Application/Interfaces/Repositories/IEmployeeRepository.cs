using Application.Dtos;

namespace Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IQueryable<EmployeeDto>> GetAll();
        Task<EmployeeDto> Get(int id);
        Task<bool> Insert(EmployeeDto employee);
        Task<bool> Update(EmployeeDto employee);
    }
}
