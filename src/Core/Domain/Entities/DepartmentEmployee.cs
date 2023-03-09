using Domain.Common;

namespace Domain.Entities
{
    public class DepartmentEmployee : BaseEntity
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
