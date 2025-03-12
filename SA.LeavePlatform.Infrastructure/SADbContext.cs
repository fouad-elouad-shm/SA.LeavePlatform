using Microsoft.EntityFrameworkCore;

using SA.LeavePlatform.Domain.Entities;

namespace SA.LeavePlatform.Infrastructure
{
    public class SADbContext : DbContext
    {
        public SADbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Affectation> Affectations { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveDoc> LeaveDocs { get; set; }

    }
}
