namespace exam_system.Domain.Entities.ContentManagement
{
    public class QuestionChoice
    {
        public Guid QuestionId { get; set; }
        public Guid OptionId { get; set; }

        public bool IsCorrect { get; set; }
        public int OrderIndex { get; set; }

        // Navigation Properties
        public Question Question { get; set; } = null!;
        public Choice Option { get; set; } = null!;
    }
}
