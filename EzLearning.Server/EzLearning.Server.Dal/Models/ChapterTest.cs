using System.Collections.Generic;

namespace EzLearning.Server.Dal.Models
{
    public class ChapterTest
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }
        public List<Question> TestQuestions { get; set; }
    }
}
