using exam_system.Domain.Common;
using exam_system.Domain.Entities.ContentManagement;
using exam_system.Domain.Entities.Identity;
using exam_system.Domain.Enums;

namespace exam_system.Domain.Entities.Examination_Assessment
{
    public class QuizAttempt : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid QuizId { get; set; }

        public AttemptStatus Status { get; set; } = AttemptStatus.InProgress;

        public int AttemptNumber { get; set; }

        // Timing
        public DateTime StartTime { get; set; }
        public DateTime Deadline { get; set; }  // = Deadline when TimedOut
        public DateTime? SubmittedAt { get; set; }   

        public int NavigationVersion { get; set; }  // protect when double click => " send Two Request" // save pos when disconnect
        public int CurrentQuestionIndex { get; set; } // save pos when disconnect

        //public DateTime ReviewReleaseAt { get; set; } // calc in busniss

        // Final Result
        public decimal? Score { get; set; }
        public bool? Passed { get; set; }

        public string QuizTitleSnapshot { get; set; } = string.Empty;
        public decimal PassScoreSnapshot { get; set; }


        public ApplicationUser Student { get; set; } = null!;
        public Quiz Quiz { get; set; } = null!;

        public ICollection<AttemptQuestion> AttemptQuestions { get; set; } = [];
    }
}
