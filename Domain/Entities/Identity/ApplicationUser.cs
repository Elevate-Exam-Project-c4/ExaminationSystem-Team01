using exam_system.Domain.Common;
using exam_system.Domain.Entities.Enroll;
using exam_system.Domain.Entities.Examination_Assessment;

namespace exam_system.Domain.Entities.Identity
{
    public class ApplicationUser : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;

        public DateTime? LastActivityAt { get; set; }  // last successful login or refresh

        public ICollection<Enrollment> Enrollments { get; set; } = [];
        public ICollection<QuizAttempt> Attempts { get; set; } = [];
    }
}
