using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Enterprise : BaseEntity
    {
        [Required]
        public string Address { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(10)]
        public string Phone { get; set; }
        public List<Department> Departments { get; set; }
    }
}
