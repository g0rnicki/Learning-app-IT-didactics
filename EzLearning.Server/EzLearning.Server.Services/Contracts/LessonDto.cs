namespace EzLearning.Server.Services.Contracts
{
    public class LessonDto
    {
        public int Id { get; set; }
        public int LessonNumber { get; set; }
        public int Part { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ChapterId { get; set; }
        public int QuestionId { get; set; }
    }
}
