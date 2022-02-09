using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_app_1.Services.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_app_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ChapterId), nameof(ChapterId))]
    public partial class LessonsPage : ContentPage
    {
        public int ChapterId { get; set; }

        private readonly IRestClient _restClient;

        public LessonsPage()
        {
            _restClient = DependencyService.Get<IRestClient>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(Lesson)}");
        }

        protected override async void OnAppearing()
        {
            var lessons = await _restClient.GetLessonsByChapterId(ChapterId);
            Console.WriteLine($"Found {lessons.Count} lessons");

            var layout = Content.FindByName<StackLayout>("ButtonStackLayout");
            layout.Children.Clear();
            var colorSecondary = (Color)Application.Current.Resources["Secondary"];
            var colorSecondaryDark = (Color)Application.Current.Resources["SecondaryDark"];
            var colorPrimary = (Color)Application.Current.Resources["Primary"];
            var colorPrimaryDark = (Color)Application.Current.Resources["PrimaryDark"];

            bool AllLessonsCompleted = true; //TUTEJ INFO Z SERWERA CZY WSZYSTKIE LEKCJE SĄ ZROBIONE
            

            foreach(var lesson in lessons.Where(l => l.Part == 1))
            {
                bool lessonCompleted = true; //TUTEJ INFO CZY DANA LEKCJA JUŻ JEST ZROBIONA

                var isCompleted = "";
                if(lessonCompleted)
                {
                    isCompleted = "✓";
                    colorSecondary = colorPrimary;
                    colorSecondaryDark = colorPrimaryDark;
                }
                var button = new Button
                {
                    Text = $"Lesson {lesson.LessonNumber}: {lesson.Title}  {isCompleted}",
                    TextColor = Color.White,
                };

                button.SetAppThemeColor(Button.BackgroundColorProperty, colorSecondary, colorSecondaryDark);
                button.Clicked += async (sender, args) =>
                {
                    Console.WriteLine($"Clicked {lesson.Title}");
                    await Shell.Current.GoToAsync($"{nameof(Lesson)}?LessonId={lesson.Id}");
                };

                layout.Children.Add(button);
               
            }
            var quiz_button = new Button
            {
                Text = $"Chapter {ChapterId} Quiz",
                TextColor = Color.White,
                IsEnabled = AllLessonsCompleted,
                Padding = 30,
            };
            quiz_button.Clicked += async (sender, args) =>
            {
                var chapterQuizQuestions = await _restClient.GetChapterQuizQuestionsByChapterId(ChapterId);

                if (chapterQuizQuestions.Any())
                {
                    var firstQuestion = chapterQuizQuestions.OrderBy(q => q.Id).First();
                    await Shell.Current.GoToAsync($"{nameof(Question)}?QuestionId={firstQuestion.Id}&LessonId=0&ChapterId={ChapterId}");
                }
                else
                {
                    // TUTAJ DAĆ INFO ŻE NIE MA JESZCZE QUIZU
                }
            };

            if (AllLessonsCompleted)
            {
                quiz_button.SetAppThemeColor(Button.BackgroundColorProperty, colorSecondary, colorSecondaryDark);
            }
            else
            {
                quiz_button.SetAppThemeColor(Button.BackgroundColorProperty, colorPrimary, colorPrimaryDark);
            }
            layout.Children.Add(quiz_button);
        }
    }
}