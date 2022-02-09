using System;

namespace Test_app_1.Services.Interfaces.Contracts
{
    public class UserFinishedLessonDto
    {
        public int? Id { get; set; }
        public Guid UserId { get; set; }
        public int LessonNumber { get; set; }
    }
}
