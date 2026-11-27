namespace exam_system.Domain.Entities.ContentManagement
{
    public class QuizQuestion 
    {
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }

        public int OrderIndex { get; set; }

        // Navigation Properties
        public Quiz Quiz { get; set; } = null!;
        public Question Question { get; set; } = null!;
    }
}
