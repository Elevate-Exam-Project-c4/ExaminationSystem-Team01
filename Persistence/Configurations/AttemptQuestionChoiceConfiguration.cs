using exam_system.Domain.Entities.Examination_Assessment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam_system.Persistence.Configurations
{
    public class AttemptQuestionChoiceConfiguration : IEntityTypeConfiguration<AttemptQuestionChoice>
    {
        public void Configure(EntityTypeBuilder<AttemptQuestionChoice> builder)
        {
            builder.ToTable("AttemptQuestionChoices");
            builder.HasKey(aqc => new { aqc.AttemptId, aqc.QuestionId, aqc.ChoiceId });

            builder.Property(aqc => aqc.Text).IsRequired().HasMaxLength(500);
            builder.Property(aqc => aqc.IsCorrect).IsRequired();
            builder.Property(aqc => aqc.OrderIndex).IsRequired();

            // Composite FK to the snapshot question.
            builder.HasOne(aqc => aqc.AttemptQuestion)
                   .WithMany(q => q.AttemptQuestionChoices)
                   .HasForeignKey(aqc => new { aqc.AttemptId, aqc.QuestionId });

            builder.HasOne(aqc => aqc.Choice)
                   .WithMany(c => c.AttemptQuestionChoices)
                   .HasForeignKey(aqc => aqc.ChoiceId);

            builder.HasIndex(aqc => new { aqc.AttemptId, aqc.QuestionId, aqc.OrderIndex }).IsUnique();
        }
    }
}
