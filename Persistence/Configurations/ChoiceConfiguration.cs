using exam_system.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam_system.Persistence.Configurations
{
    public class ChoiceConfiguration: BaseEntityConfiguration<Choice>
    {
        public override void Configure(EntityTypeBuilder<Choice> builder)
        {
            base.Configure(builder);
            builder.ToTable("Choices");

            builder.Property(c => c.Text).IsRequired().HasMaxLength(500);
        }
    }
}
