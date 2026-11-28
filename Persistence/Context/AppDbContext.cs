using exam_system.Domain.Entities.ContentManagement;
using exam_system.Domain.Entities.Enroll;
using exam_system.Persistence.Configurations.Extenstions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace exam_system.Persistence.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("ConnectionString"); 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);                    // required for Identity tables
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.UseRestrictDeleteBehavior();              // after the configurations are applied
        modelBuilder.ApplySoftDeleteFilter();
    }

    public DbSet<Diploma> Diplomas { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
}
