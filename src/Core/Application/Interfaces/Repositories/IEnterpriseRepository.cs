using Application.Dtos;

namespace Application.Interfaces.Repositories
{
    public interface IEnterpriseRepository
    {
        Task<IQueryable<EnterpriseDto>> GetAll();
        Task<EnterpriseDto> Get(int id);
        Task<bool> Insert(EnterpriseDto enterprise);
        Task<bool> Update(EnterpriseDto enterprise);
    }
}
