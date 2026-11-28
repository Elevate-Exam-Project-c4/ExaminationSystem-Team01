using exam_system.Domain.Common;
using exam_system.Domain.Entities.Examination_Assessment;

namespace exam_system.Domain.Entities.ContentManagement
{
    public class Choice  : BaseEntity
    {
        public string Text { get; set; } = string.Empty;

        public ICollection<QuestionChoice> QuestionChoices { get; set; } = [];

        public ICollection<AttemptQuestionChoice> AttemptQuestionChoices { get; set; } = [];
    }
}
