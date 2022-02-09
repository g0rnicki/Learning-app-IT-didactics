using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_app_1.Services.Interfaces;
using Test_app_1.Services.Interfaces.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_app_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(QuestionId), nameof(QuestionId))]
    [QueryProperty(nameof(LessonId), nameof(LessonId))]
    [QueryProperty(nameof(ChapterId), nameof(ChapterId))]
    public partial class Question : ContentPage
    {
        public int QuestionId { get; set; }
        public int LessonId { get; set; }
        public int ChapterId { get; set; }

        private readonly IRestClient _restClient;

        private static Random rng = new Random();

        public Question()
        {
            _restClient = DependencyService.Get<IRestClient>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var currentQuestionTask = _restClient.GetQuestionById(QuestionId);
            var currentQuestion = await currentQuestionTask;

            var titleLabel = Content.FindByName<Label>("Title");

            var contentStackLayout = Content.FindByName<StackLayout>("ContentStackLayout");
            contentStackLayout.Children.Clear();

            string[] separator = { "\\n" };

            foreach (var cont in currentQuestion.QuestionContent.Split(separator, StringSplitOptions.RemoveEmptyEntries))
            {
                var label = new Label
                {
                    Text = cont,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
                contentStackLayout.Children.Add(label);
            }

            if (LessonId > 0)
            {
                var currentLesson = await _restClient.GetLessonById(LessonId);
                titleLabel.Text = currentLesson.Title;
                SetButtonsAfterLesson(currentQuestion, currentLesson);
            }
            else if (ChapterId > 0)
            {
                titleLabel.Text = string.Empty;
                await SetButtonsInQuiz(currentQuestion);
            }
        }

        private void SetButtonsAfterLesson(QuestionDto question, LessonDto currentLesson)
        {
            var allButtons = new List<Button>();

            allButtons.AddRange(new[] {
                Content.FindByName<Button>("Button1"),
                Content.FindByName<Button>("Button2"),
                Content.FindByName<Button>("Button3"),
                Content.FindByName<Button>("Button4"),
            });

            var shuffledButtons = allButtons.OrderBy(a => rng.Next()).ToList();

            shuffledButtons[0].Text = question.CorrectAnswer.AnswerContent;
            shuffledButtons[0].Clicked += async (sender, args) =>
            {
                await Shell.Current.GoToAsync(await GetNextNavigationPath(currentLesson));
                Console.WriteLine($"Good answer");
            };
            shuffledButtons.RemoveAt(0);

            foreach (var badAnswer in question.WrongAnswers.Zip(shuffledButtons, (a, b) => (a, b)))
            {
                badAnswer.b.Text = badAnswer.a.AnswerContent.Replace("\\n", "\n");
                badAnswer.b.Clicked += async (sender, args) =>
                {
                    var clickedButton = sender as Button;
                    clickedButton.IsEnabled = false;
                    clickedButton.BackgroundColor = Color.Gray;
                    // TUTEJ ZLICZAJ ILE RAZY BŁĘDNA ODPOWIEDŹ
                    Console.WriteLine($"Bad answer");
                };
            }
        }

        private async Task<string> GetNextNavigationPath(LessonDto currentLesson)
        {
            if (currentLesson.Part == 1)
            {
                var nextLessonId = await _restClient.GetLessonIdByLessonNumberAndPart(currentLesson.LessonNumber, 2);
                return $"{nameof(Lesson)}?LessonId={nextLessonId}";
            }
            else
            {
                await SaveLessonFinished(currentLesson);
                return $"{nameof(LessonsPage)}?ChapterId={currentLesson.ChapterId}";
            }
        }

        private Task SaveLessonFinished(LessonDto lesson)
        {
            var lessonFinished = new UserFinishedLessonDto
            {
                LessonNumber = lesson.LessonNumber,
                UserId = _restClient.GetCurrentUserId()
            };

            return _restClient.SaveUserProgress(lessonFinished);
        }

        private async Task SetButtonsInQuiz(QuestionDto currentQuestion)
        {
            var allButtons = new List<Button>();

            allButtons.AddRange(new[] {
                Content.FindByName<Button>("Button1"),
                Content.FindByName<Button>("Button2"),
                Content.FindByName<Button>("Button3"),
                Content.FindByName<Button>("Button4"),
            });

            var shuffledButtons = allButtons.OrderBy(a => rng.Next()).ToList();

            var chapterQuestions = await _restClient.GetChapterQuizQuestionsByChapterId(ChapterId);
            var nextQuestion = chapterQuestions.Find(q => q.Id == currentQuestion.Id + 1);

            var nextPagePath = nextQuestion == null ?
                $"{nameof(LessonsPage)}?ChapterId={ChapterId}" :
                $"{nameof(Question)}?QuestionId={nextQuestion.Id}&LessonId=0&ChapterId={ChapterId}";

            shuffledButtons[0].Text = currentQuestion.CorrectAnswer.AnswerContent;
            shuffledButtons[0].Clicked += async (sender, args) =>
            {
                await Shell.Current.GoToAsync(nextPagePath);
                Console.WriteLine($"Good answer");
            };
            shuffledButtons.RemoveAt(0);

            foreach (var badAnswer in currentQuestion.WrongAnswers.Zip(shuffledButtons, (a, b) => (a, b)))
            {
                badAnswer.b.Text = badAnswer.a.AnswerContent.Replace("\\n", "\n");
                badAnswer.b.Clicked += async (sender, args) =>
                {
                    var clickedButton = sender as Button;
                    clickedButton.IsEnabled = false;
                    clickedButton.BackgroundColor = Color.Gray;
                    // TUTEJ ZLICZAJ ILE RAZY BŁĘDNA ODPOWIEDŹ
                    Console.WriteLine($"Bad answer");
                };
            }
        }
    }
}