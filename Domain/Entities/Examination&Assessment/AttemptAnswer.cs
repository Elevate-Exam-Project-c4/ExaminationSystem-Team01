namespace exam_system.Domain.Entities.Examination_Assessment
{
    public class AttemptAnswer 
    {
        public Guid AttemptId { get; set; }
        public Guid QuestionId { get; set; }

        public Guid? SelectedChoiceId { get; set; }

        public bool? IsCorrect { get; set; }

        public DateTime AnsweredAt { get; set; }

        // Navigation Properties
        public AttemptQuestion AttemptQuestion { get; set; } = null!;

        public AttemptQuestionChoice? SelectedOption { get; set; }
    }
}
