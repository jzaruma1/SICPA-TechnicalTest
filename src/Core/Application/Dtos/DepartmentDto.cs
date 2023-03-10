using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos
{
    public class DepartmentDto: BaseEntityDto
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int EnterpriseId { get; set; }
        public string EnterpriseName { get; set; }
        public string EmployeeNames { get; set; }
    }
}
