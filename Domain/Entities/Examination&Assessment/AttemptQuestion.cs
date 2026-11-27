using exam_system.Domain.Entities.ContentManagement;

namespace exam_system.Domain.Entities.Examination_Assessment
{
    public class AttemptQuestion
    {
        public Guid AttemptId { get; set; }
        public Guid QuestionId { get; set; }

        public string Text { get; set; } = string.Empty;
        public string? Explanation { get; set; }

        public int OrderIndex { get; set; }


        // Navigation Properties
        public QuizAttempt Attempt { get; set; } = null!;
        public Question Question { get; set; } = null!;

        public ICollection<AttemptQuestionChoice> AttemptQuestionChoices { get; set; }
            = new List<AttemptQuestionChoice>();

        public AttemptAnswer? Answer { get; set; }
    }
}
