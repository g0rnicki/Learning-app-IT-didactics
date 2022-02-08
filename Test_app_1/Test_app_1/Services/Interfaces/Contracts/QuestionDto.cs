namespace Test_app_1.Services.Interfaces.Contracts
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public AnswerDto CorrectAnswer { get; set; }
        public AnswerDto[] WrongAnswers { get; set; }
    }
}
