namespace EzLearning.Server.Dal.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int LessonNumber { get; set; }
        public int Part { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
