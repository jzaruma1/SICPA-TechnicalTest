using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enterprise>(e =>
            {
                e.HasMany(x => x.Departments).WithOne().HasForeignKey(x => x.EnterpriseId);
            });

            modelBuilder.Entity<DepartmentEmployee>()
                .HasOne(de => de.Department)
                .WithMany(d => d.DepartmentEmployees)
                .HasForeignKey(de => de.DepartmentId);

            modelBuilder.Entity<DepartmentEmployee>()
                .HasOne(de => de.Employee)
                .WithMany(e => e.DepartmentEmployees)
                .HasForeignKey(de => de.EmployeeId);
        }
    }
}
