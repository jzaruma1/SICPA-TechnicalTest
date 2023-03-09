using Application.Dtos;
using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EnterpriseRepository(DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IQueryable<EnterpriseDto>> GetAll()
        {
            return _context.Enterprises.ProjectTo<EnterpriseDto>(_mapper.ConfigurationProvider);
        }

        public async Task<EnterpriseDto> Get(int id)
        {
            return await _context.Enterprises.Where(x => x.Id == id).ProjectTo<EnterpriseDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<bool> Insert(EnterpriseDto enterprise)
        {
            var entity = _mapper.Map<EnterpriseDto, Enterprise>(enterprise);
            _context.Enterprises.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(EnterpriseDto enterprise)
        {
            var entity = _mapper.Map<EnterpriseDto, Enterprise>(enterprise);
            _context.Enterprises.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
