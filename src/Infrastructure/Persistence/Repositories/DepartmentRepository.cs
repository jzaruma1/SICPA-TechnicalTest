using Application.Dtos;
using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IQueryable<DepartmentDto>> GetAll()
        {
            return _context.Departments.ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider);
        }

        public async Task<DepartmentDto> Get(int id)
        {
            return await _context.Departments.Where(x => x.Id == id).ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<bool> Insert(DepartmentDto department)
        {
            var entity = _mapper.Map<DepartmentDto, Department>(department);
            _context.Departments.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(DepartmentDto department)
        {
            var entity = _mapper.Map<DepartmentDto, Department>(department);
            _context.Departments.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
