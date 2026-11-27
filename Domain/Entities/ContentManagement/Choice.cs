using exam_system.Domain.Entities.Examination_Assessment;

namespace exam_system.Domain.Entities.ContentManagement
{
    public class Choice  
    {
        public string Text { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<QuestionChoice> QuestionOptions { get; set; }
            = new List<QuestionChoice>();

        public ICollection<AttemptQuestionChoice> AttemptQuestionOptions { get; set; }
            = new List<AttemptQuestionChoice>();
    }
}
