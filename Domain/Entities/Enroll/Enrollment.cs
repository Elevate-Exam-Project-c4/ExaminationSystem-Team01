using exam_system.Domain.Entities.ContentManagement;

namespace exam_system.Domain.Entities.Enroll
{
    public class Enrollment 
    {
        public Guid StudentId { get; set; }
        public Guid DiplomaId { get; set; }

        //public DateTime EnrolledAt { get; set; } same craeted at 

        // Navigation Properties
        // public ApplicationUser Student { get; set; } = null!; bissness user or app + bissness
        public Diploma Diploma { get; set; } = null!;
    }
}
