using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int Age { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(200)]
        public string Position { get; set; }
        [Required, MaxLength(100)]
        public string Surname { get; set; }
        public ICollection<DepartmentEmployee> DepartmentEmployees { get; set; }

    }
}
