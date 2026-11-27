using exam_system.Domain.Entities.Examination_Assessment;

namespace exam_system.Domain.Entities.ContentManagement
{
    public class Quiz 
    {
        public Guid DiplomaId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? Instructions { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int DurationMinutes { get; set; }
        public decimal PassScore { get; set; } = 60m;
        public int? MaxAttempts { get; set; }

        //public string Status { get; set; } = QuizStatuses.Draft; enum
        public DateTime? PublishedAt { get; set; }

        // Navigation Properties
        public Diploma Diploma { get; set; } = null!;

        public ICollection<QuizQuestion> QuizQuestions { get; set; }
            = new List<QuizQuestion>();

        public ICollection<QuizAttempt> Attempts { get; set; }
            = new List<QuizAttempt>();
    }
}
