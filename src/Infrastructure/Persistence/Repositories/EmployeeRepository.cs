using Application.Dtos;
using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EmployeeRepository(DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IQueryable<EmployeeDto>> GetAll()
        {
            return _context.Employees.ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider);
        }

        public async Task<EmployeeDto> Get(int id)
        {
            return await _context.Employees.Where(x => x.Id == id).ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<Employee> GetEntity(int id)
        {
            return await _context.Employees.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<bool> Insert(EmployeeDto employee)
        {
            var entity = _mapper.Map<EmployeeDto, Employee>(employee);
            _context.Employees.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(EmployeeDto employee)
        {
            var entity = _mapper.Map<EmployeeDto, Employee>(employee);
            _context.Employees.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
