using exam_system.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exam_system.Persistence.Configurations
{
    public class DiplomaConfiguration: BaseEntityConfiguration<Diploma>
    {
        public override void Configure(EntityTypeBuilder<Diploma> builder)
        {
            base.Configure(builder);
            builder.ToTable("Diplomas");

            builder.Property(d => d.Title).IsRequired().HasMaxLength(200);
        }
    
    }
}
