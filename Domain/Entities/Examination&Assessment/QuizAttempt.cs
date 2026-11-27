using exam_system.Domain.Entities.ContentManagement;

namespace exam_system.Domain.Entities.Examination_Assessment
{
    public class QuizAttempt
    {
        public Guid StudentId { get; set; }
        public Guid QuizId { get; set; }

        public int AttemptNumber { get; set; }
        //public string Status { get; set; } = AttemptStatuses.InProgress; enum

        // Timing
        public DateTime StartTime { get; set; }
        public DateTime? SubmittedAt { get; set; }

        //// Navigation State
        //public int NavigationVersion { get; set; }
        //public int CurrentQuestionIndex { get; set; }

        //// Quiz Settings Snapshot
        //public string QuizTitleSnapshot { get; set; } = string.Empty;
        //public DateTime StartDateSnapshot { get; set; }
        //public DateTime EndDateSnapshot { get; set; }
        //public int DurationMinutesSnapshot { get; set; }
        //public decimal PassScoreSnapshot { get; set; }
        //public int? MaxAttemptsSnapshot { get; set; }

        //public DateTime ReviewReleaseAt { get; set; }

        // Final Result
        public decimal? Score { get; set; }
        public bool? Passed { get; set; }

        // Navigation Properties
        //public ApplicationUser Student { get; set; } = null!;
        public Quiz Quiz { get; set; } = null!;

        public ICollection<AttemptQuestion> AttemptQuestions { get; set; }
            = new List<AttemptQuestion>();
    }
}
