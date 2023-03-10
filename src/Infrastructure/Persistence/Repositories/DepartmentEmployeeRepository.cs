using Application.Dtos;
using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class DepartmentEmployeeRepository : IDepartmentEmployeeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DepartmentEmployeeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddOrUpdateRelations(int employeeId, List<int> departments)
        {
            var currentRelations = await ListByEmployee(employeeId);
            var deleteRelations = currentRelations.Where(x => !departments.Contains(x.DepartmentId));
            var insertRelations = departments.Where(x => !currentRelations.Select(c => c.DepartmentId).Contains(x));

            foreach (var item in deleteRelations)
            {
                _context.DepartmentEmployees.Remove(item);
            }

            foreach (var item in insertRelations)
            {
                _context.DepartmentEmployees.Add(new DepartmentEmployee() { DepartmentId = item, EmployeeId = employeeId });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<DepartmentEmployee>> ListByEmployee(int employeeId)
        {
            return _context.DepartmentEmployees.Where(x => x.EmployeeId == employeeId);
        }

    }
}
