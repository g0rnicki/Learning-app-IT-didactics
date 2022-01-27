using System.Collections.Generic;

namespace EzLearning.Server.Dal.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List <Lesson> Lessons { get; set; }
    }
}
