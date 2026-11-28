using exam_system.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam_system.Persistence.Configurations
{
    public class QuestionConfiguration: BaseEntityConfiguration<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            base.Configure(builder);
            builder.ToTable("Questions");

            builder.Property(q => q.Text).IsRequired().HasMaxLength(2000);
            builder.Property(q => q.Explanation).HasMaxLength(2000);

            builder.HasIndex(q => q.IsDeleted);
        }
    }
}
