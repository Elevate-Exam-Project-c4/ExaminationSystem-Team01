using exam_system.Domain.Entities.ContentManagement;

namespace exam_system.Domain.Entities.Examination_Assessment
{
    public class AttemptQuestionChoice
    {
        public Guid AttemptId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid OptionId { get; set; }

        public string Text { get; set; } = string.Empty;

        public bool IsCorrect { get; set; }
        public int OrderIndex { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public AttemptQuestion AttemptQuestion { get; set; } = null!;
        public Choice Choice { get; set; } = null!;
    }
}
