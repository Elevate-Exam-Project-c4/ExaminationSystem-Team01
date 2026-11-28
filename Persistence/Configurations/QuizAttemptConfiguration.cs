using exam_system.Domain.Entities.Examination_Assessment;
using exam_system.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam_system.Persistence.Configurations
{
    public class QuizAttemptConfiguration: BaseEntityConfiguration<QuizAttempt>
    {
        public override void Configure(EntityTypeBuilder<QuizAttempt> builder)
        {
            base.Configure(builder);
            builder.ToTable("QuizAttempts", t =>
            {
                t.HasCheckConstraint("CK_QuizAttempts_Score", "[Score] IS NULL OR ([Score] >= 0 AND [Score] <= 100)");
            });

            builder.Property(qa => qa.Status).HasConversion<string>().IsRequired();
            builder.Property(qa => qa.StartTime).IsRequired();
            builder.Property(qa => qa.Deadline).IsRequired();
            builder.Property(qa => qa.Score).HasPrecision(5, 2);

            builder.Property(qa => qa.QuizTitleSnapshot).IsRequired().HasMaxLength(200);
            builder.Property(qa => qa.PassScoreSnapshot).HasPrecision(5, 2);

            builder.HasOne(qa => qa.Quiz)
                   .WithMany(q => q.Attempts)
                   .HasForeignKey(qa => qa.QuizId);

            builder.HasOne(qa => qa.Student)
                   .WithMany(s => s.Attempts)
                   .HasForeignKey(qa => qa.StudentId);

            // One in-progress attempt per student across the whole system.
             //The literal must match what is stored: HasConversion<string>() stores the enum NAME.
            builder.HasIndex(qa => qa.StudentId)
                   .IsUnique()
                   .HasFilter("[Status] = 'InProgress' AND [IsDeleted] = 0")
                   .HasDatabaseName("UX_QuizAttempts_OneActivePerStudent");

        builder.HasIndex(qa => new { qa.StudentId, qa.QuizId });
            builder.HasIndex(qa => new { qa.QuizId, qa.Status, qa.Deadline });
            builder.HasIndex(qa => new { qa.StudentId, qa.SubmittedAt });
            builder.HasIndex(qa => new { qa.Status, qa.Deadline });   // recovery scans
        }
    }
}
