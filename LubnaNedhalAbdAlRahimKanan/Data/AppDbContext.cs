using Microsoft.EntityFrameworkCore;
using LubnaNedhalAbdAlRahimKanan.Models;

namespace LubnaNedhalAbdAlRahimKanan.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<RequestState> RequestStates { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasOne<Position>()
                .WithMany()
                .HasForeignKey(e => e.PositionId);

            modelBuilder.Entity<VacationRequest>()
                .HasOne<Employee>()
                .WithMany()
                .HasForeignKey(v => v.EmployeeNumber);

            modelBuilder.Entity<VacationRequest>()
                .HasOne<RequestState>()
                .WithMany()
                .HasForeignKey(v => v.RequestStateId);
        }
    }
}
