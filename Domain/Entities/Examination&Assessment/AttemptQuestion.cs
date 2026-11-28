using exam_system.Domain.Common;
using exam_system.Domain.Entities.ContentManagement;

namespace exam_system.Domain.Entities.Examination_Assessment
{
    public class AttemptQuestion: AuditableEntity
    {
        public Guid AttemptId { get; set; }
        public Guid QuestionId { get; set; }

        public string Text { get; set; } = string.Empty;
        public string? Explanation { get; set; }

        public int OrderIndex { get; set; }
        public QuizAttempt Attempt { get; set; } = null!;
        public Question Question { get; set; } = null!;

        public ICollection<AttemptQuestionChoice> AttemptQuestionChoices { get; set; } = [];

        public AttemptAnswer? Answer { get; set; }
    }
}
