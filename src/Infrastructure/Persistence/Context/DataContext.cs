using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasOne(p => p.Enterprise)
                .WithMany(b => b.Departments);

            modelBuilder.Entity<Employee>()
    .HasMany(p => p.DepartmentEmployees);

            modelBuilder.Entity<DepartmentEmployee>()
                .HasOne(de => de.Department)
                .WithMany(d => d.DepartmentEmployees)
                .HasForeignKey(de => de.DepartmentId);

            modelBuilder.Entity<DepartmentEmployee>()
                .HasOne(de => de.Employee)
                .WithMany(e => e.DepartmentEmployees)
                .HasForeignKey(de => de.EmployeeId);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "user-admin-create";
                        entry.Entity.ModifiedDate = DateTime.UtcNow;
                        entry.Entity.ModifiedBy = "user-admin-create";
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.UtcNow;
                        entry.Entity.ModifiedBy = "user-admin-edit";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
