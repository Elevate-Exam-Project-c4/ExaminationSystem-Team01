using exam_system.Domain.Entities.ContentManagement;
using exam_system.Domain.Entities.Examination_Assessment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam_system.Persistence.Configurations
{
    public class AttemptQuestionConfiguration: IEntityTypeConfiguration<AttemptQuestion>
    {
        public void Configure(EntityTypeBuilder<AttemptQuestion> builder)
        {
            builder.ToTable("AttemptQuestions");
            builder.HasKey(aq => new { aq.AttemptId, aq.QuestionId });

            builder.Property(aq => aq.Text).IsRequired().HasMaxLength(2000);
            builder.Property(aq => aq.Explanation).HasMaxLength(2000);
            builder.Property(aq => aq.OrderIndex).IsRequired();

            builder.HasOne(aq => aq.Attempt)
                   .WithMany(a => a.AttemptQuestions)
                   .HasForeignKey(aq => aq.AttemptId);

            builder.HasOne(aq => aq.Question)
                   .WithMany(q => q.AttemptQuestions)
                   .HasForeignKey(aq => aq.QuestionId);

            builder.HasIndex(aq => new { aq.AttemptId, aq.OrderIndex }).IsUnique();
        }
    }
}
