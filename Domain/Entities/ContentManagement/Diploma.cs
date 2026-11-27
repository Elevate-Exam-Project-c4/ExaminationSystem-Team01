using exam_system.Domain.Entities.Enroll;

namespace exam_system.Domain.Entities.ContentManagement
{
    public class Diploma 
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Navigation Properties
        public ICollection<Quiz> Quizzes { get; set; }
            = new List<Quiz>();

       
        public ICollection<Enrollment> Enrollments { get; set; }
            = new List<Enrollment>();
    }
}
