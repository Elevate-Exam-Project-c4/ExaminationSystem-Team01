using exam_system.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam_system.Persistence.Configurations
{
    public class QuizConfiguration: BaseEntityConfiguration<Quiz>
    {
        public override void Configure(EntityTypeBuilder<Quiz> builder)
        {
            base.Configure(builder);
            builder.ToTable("Quizzes", t =>
            {
                t.HasCheckConstraint("CK_Quizzes_EndAfterStart", "[EndDate] > [StartDate]");
                t.HasCheckConstraint("CK_Quizzes_Duration", "[DurationMinutes] > 0");
                t.HasCheckConstraint("CK_Quizzes_MaxAttempts", "[MaxAttempts] IS NULL OR [MaxAttempts] > 0");
                t.HasCheckConstraint("CK_Quizzes_PassScore", "[PassScore] >= 0 AND [PassScore] <= 100");
            });

            builder.Property(q => q.Title).IsRequired().HasMaxLength(200);
            builder.Property(q => q.Instructions).HasMaxLength(2000);
            builder.Property(q => q.StartDate).IsRequired();
            builder.Property(q => q.EndDate).IsRequired();
            builder.Property(q => q.DurationMinutes).IsRequired();

            builder.Property(q => q.PassScore).HasPrecision(5, 2);
            builder.Property(q => q.Status).HasConversion<string>().IsRequired();

            builder.HasOne(q => q.Diploma)
               .WithMany(d => d.Quizzes)
               .HasForeignKey(q => q.DiplomaId);

            builder.HasIndex(q => new { q.DiplomaId, q.Status, q.IsDeleted });

        }

    }
}
