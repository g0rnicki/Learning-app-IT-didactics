using System;

namespace EzLearning.Server.Dal.Models
{
    public class UserFinishedLesson
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int LessonNumber { get; set; }
    }
}
