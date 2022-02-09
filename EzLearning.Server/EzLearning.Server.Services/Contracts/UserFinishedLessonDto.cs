using System;

namespace EzLearning.Server.Services.Contracts
{
    public class UserFinishedLessonDto
    {
        public int? Id { get; set; }
        public Guid UserId { get; set; }
        public int LessonNumber { get; set; }
    }
}
