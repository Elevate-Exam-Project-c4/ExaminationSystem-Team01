using exam_system.Domain.Entities.Enroll;
using exam_system.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam_system.Persistence.Configurations
{
    public class EnrollmentConfiguration: BaseEntityConfiguration<Enrollment>
    {
        public override void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            base.Configure(builder);
            builder.ToTable("Enrollments");

            builder.HasOne(e => e.Diploma)
                .WithMany(d => d.Enrollments)
                .HasForeignKey(e => e.DiplomaId);

            builder.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            builder.HasIndex(e => new { e.StudentId, e.DiplomaId }).IsUnique();
        }
    }
}
