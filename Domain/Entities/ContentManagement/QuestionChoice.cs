using exam_system.Domain.Common;

namespace exam_system.Domain.Entities.ContentManagement
{
    public class QuestionChoice: SoftDeletableEntity
    {
        public Guid QuestionId { get; set; }
        public Guid ChoiceId { get; set; }

        public bool IsCorrect { get; set; }
        public int OrderIndex { get; set; }
        public Question Question { get; set; } = null!;
        public Choice Choice { get; set; } = null!;
    }
}
