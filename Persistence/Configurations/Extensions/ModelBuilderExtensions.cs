using exam_system.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace exam_system.Persistence.Configurations.Extenstions
{
    public static class ModelBuilderExtensions
    {
        // Every FK uses restricted delete (also avoids SQL Server "multiple cascade paths" errors).
        public static void UseRestrictDeleteBehavior(this ModelBuilder modelBuilder)
        {
            foreach (var fk in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()))
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        // Hides soft-deleted rows from every query on an ISoftDeletable entity.
        public static void ApplySoftDeleteFilter(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                         .Where(t => typeof(SoftDeletableEntity).IsAssignableFrom(t.ClrType)))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var isNotDeleted = Expression.Equal(
                    Expression.Property(parameter, nameof(SoftDeletableEntity.IsDeleted)),
                    Expression.Constant(false));

                entityType.SetQueryFilter(Expression.Lambda(isNotDeleted, parameter));
            }
        }
    }
}
