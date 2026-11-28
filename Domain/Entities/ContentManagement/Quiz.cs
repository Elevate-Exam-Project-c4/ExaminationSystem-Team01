using exam_system.Domain.Common;
using exam_system.Domain.Entities.Examination_Assessment;
using exam_system.Domain.Enums;

namespace exam_system.Domain.Entities.ContentManagement
{
    public class Quiz : BaseEntity
    {
        public Guid DiplomaId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? Instructions { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int DurationMinutes { get; set; }
        public decimal PassScore { get; set; }
        public int? MaxAttempts { get; set; }

        public QuizStatus Status { get; set; } = QuizStatus.Draft;
        public DateTime? PublishedAt { get; set; }

        public Diploma Diploma { get; set; } = null!;

        public ICollection<QuizQuestion> QuizQuestions { get; set; } = [];

        public ICollection<QuizAttempt> Attempts { get; set; } = [];
    }
}
