﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(100)]
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
    }
}
