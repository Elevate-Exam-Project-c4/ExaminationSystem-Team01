using exam_system.Domain.Entities.Examination_Assessment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam_system.Persistence.Configurations
{
    public class AttemptAnswerCongifguration: BaseEntityConfiguration<AttemptAnswer>
    {
        public override void Configure(EntityTypeBuilder<AttemptAnswer> builder)
        {
            base.Configure(builder);
            builder.ToTable("AttemptAnswers");

            builder.Property(aa => aa.AnsweredAt).IsRequired();
            
            builder.HasIndex(aa => new { aa.AttemptId, aa.QuestionId }).IsUnique();

            builder.HasOne(aa => aa.AttemptQuestion)
                .WithOne(aq => aq.Answer)
                .HasForeignKey<AttemptAnswer>(aa => new { aa.AttemptId, aa.QuestionId })
                .OnDelete(DeleteBehavior.Restrict);
        }   
    }
}
