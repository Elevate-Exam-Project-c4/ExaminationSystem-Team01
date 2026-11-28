using exam_system.Domain.Common;
using exam_system.Domain.Entities.Enroll;

namespace exam_system.Domain.Entities.ContentManagement
{
    public class Diploma  : BaseEntity
    {
          public string Title { get; set; } = string.Empty;
          public string? Description { get; set; }
          public ICollection<Quiz> Quizzes { get; set; } = [];

          public ICollection<Enrollment> Enrollments { get; set; }= [];
    }
}
