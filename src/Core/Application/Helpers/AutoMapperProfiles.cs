using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.EnterpriseName, opt => opt.MapFrom(src => src.Enterprise.Name))
                .ForMember(dest => dest.EmployeeNames, opt => opt.MapFrom(src => string.Join(",", src.DepartmentEmployees.Select(d => d.Employee.Name).ToArray())));
            CreateMap<DepartmentDto, Department>();
            CreateMap<EnterpriseDto, Enterprise>();
            CreateMap<Enterprise, EnterpriseDto>()
                .ForMember(dest => dest.DepartmentNames, opt => opt.MapFrom(src => string.Join(",", src.Departments.Select(d => d.Name).ToArray())));
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.DepartmentNames, opt => opt.MapFrom(src => string.Join(",", src.DepartmentEmployees.Select(d => d.Department.Name).ToArray())));
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
