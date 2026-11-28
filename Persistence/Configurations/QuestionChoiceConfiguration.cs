using exam_system.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam_system.Persistence.Configurations
{
    public class QuestionChoiceConfiguration: IEntityTypeConfiguration<QuestionChoice>
    {
        public void Configure(EntityTypeBuilder<QuestionChoice> builder)
        {
            builder.ToTable("QuestionChoices", t =>
            {
                t.HasCheckConstraint("CK_QuestionChoices_OrderIndex", "[OrderIndex] >= 0");
            });

            builder.HasKey(x => new { x.QuestionId, x.ChoiceId });

            builder.HasOne(x => x.Question)
                   .WithMany(q => q.QuestionChoices)
                   .HasForeignKey(x => x.QuestionId);

            builder.HasOne(x => x.Choice)
                   .WithMany(c => c.QuestionChoices)
                   .HasForeignKey(x => x.ChoiceId);

            builder.HasIndex(x => new { x.ChoiceId, x.IsDeleted });

            // At most one ACTIVE correct choice per question.
            builder.HasIndex(x => x.QuestionId)
                   .IsUnique()
                   .HasFilter("[IsCorrect] = 1 AND [IsDeleted] = 0")
                   .HasDatabaseName("UX_QuestionChoices_OneCorrectPerQuestion");
        }
    }
}
