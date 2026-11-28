using exam_system.Domain.Common;

namespace exam_system.Domain.Entities.Examination_Assessment
{
    // TODO : Should Add AuditableEntity To Avoide Use ID In This Class 
    public class AttemptAnswer: BaseEntity
    {
        public Guid AttemptId { get; set; }
        public Guid QuestionId { get; set; }

        public Guid? SelectedChoiceId { get; set; }  // fluant api configuration 

        public bool? IsCorrect { get; set; }

        public DateTime AnsweredAt { get; set; }

        public AttemptQuestion AttemptQuestion { get; set; } = null!;

        public AttemptQuestionChoice? SelectedChoice { get; set; }
    }
}
