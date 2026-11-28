using exam_system.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam_system.Persistence.Configurations
{
    public class QuizQuestionConfiguration: IEntityTypeConfiguration<QuizQuestion>
    {
        public void Configure(EntityTypeBuilder<QuizQuestion> builder)
        {
            builder.ToTable("QuizQuestions", t =>
            {
                t.HasCheckConstraint("CK_QuizQuestions_OrderIndex", "[OrderIndex] >= 0");
            });

            builder.HasKey(qq => new { qq.QuizId, qq.QuestionId });

            builder.HasOne(qq => qq.Quiz)
                   .WithMany(q => q.QuizQuestions)
                   .HasForeignKey(qq => qq.QuizId);

            builder.HasOne(qq => qq.Question)
                   .WithMany(q => q.QuizQuestions)
                   .HasForeignKey(qq => qq.QuestionId);

            builder.HasIndex(qq => new { qq.QuestionId, qq.IsDeleted });          // "is this question used?" guard

            // Unique position among ACTIVE questions of a quiz.
            builder.HasIndex(qq => new { qq.QuizId, qq.OrderIndex })
                   .IsUnique()
                   .HasFilter("[IsDeleted] = 0")
                   .HasDatabaseName("UX_QuizQuestions_ActiveOrder");
        }
    }
}
