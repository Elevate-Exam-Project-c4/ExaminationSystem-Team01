using exam_system.Domain.Entities.Examination_Assessment;

namespace exam_system.Domain.Entities.ContentManagement
{
    public class Question 
    {
        public string Text { get; set; } = string.Empty;
        public string? Explanation { get; set; }

        // Navigation Properties
        public ICollection<QuestionChoice> QuestionOptions { get; set; }
            = new List<QuestionChoice>();

        public ICollection<QuizQuestion> QuizQuestions { get; set; }
            = new List<QuizQuestion>();

        public ICollection<AttemptQuestion> AttemptQuestions { get; set; }
            = new List<AttemptQuestion>();
    }
}
