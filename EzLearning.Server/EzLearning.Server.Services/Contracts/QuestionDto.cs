namespace EzLearning.Server.Services.Contracts
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public AnswerDto CorrectAnswer { get; set; }
        public AnswerDto[] WrongAnswers { get; set; }
    }
}
