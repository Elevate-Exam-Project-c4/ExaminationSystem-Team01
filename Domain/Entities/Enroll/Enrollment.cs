using exam_system.Domain.Common;
using exam_system.Domain.Entities.ContentManagement;
using exam_system.Domain.Entities.Identity;

namespace exam_system.Domain.Entities.Enroll
{
    public class Enrollment  : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid DiplomaId { get; set; }

        //public DateTime EnrolledAt { get; set; } same craeted at 
         public ApplicationUser Student { get; set; } = null!;
        public Diploma Diploma { get; set; } = null!;
    }
}
