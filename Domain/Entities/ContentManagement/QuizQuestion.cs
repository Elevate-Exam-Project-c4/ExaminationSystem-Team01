using exam_system.Domain.Common;

namespace exam_system.Domain.Entities.ContentManagement
{
    public class QuizQuestion: SoftDeletableEntity
    {
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }

        public int OrderIndex { get; set; }

        public Quiz Quiz { get; set; } = null!;
        public Question Question { get; set; } = null!;
    }
}
