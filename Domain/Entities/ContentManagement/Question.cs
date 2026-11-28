using exam_system.Domain.Common;
using exam_system.Domain.Entities.Examination_Assessment;

namespace exam_system.Domain.Entities.ContentManagement
{
    public class Question : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public string? Explanation { get; set; }

        public ICollection<QuestionChoice> QuestionChoices { get; set; }= [];

        public ICollection<AttemptQuestion> AttemptQuestions { get; set; } = [];
    }
}
