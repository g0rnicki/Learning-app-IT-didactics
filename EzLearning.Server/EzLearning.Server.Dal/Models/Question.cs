using System.Collections.Generic;

namespace EzLearning.Server.Dal.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int CorrectAnswerId { get; set; }
        public QuestionAnswer CorrectAnswer { get; set; }
        public List<QuestionAnswer> WrongAnswers { get; set; }
    }
}
