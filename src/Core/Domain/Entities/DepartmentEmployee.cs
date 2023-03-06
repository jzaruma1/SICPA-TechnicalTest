using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
