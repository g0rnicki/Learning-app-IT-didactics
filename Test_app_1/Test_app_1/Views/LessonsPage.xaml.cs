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
            await Shell.Current.GoToAsync($"{nameof(LessonsPage)}");
        }

        protected override async void OnAppearing()
        {
            var lessons = await _restClient.GetLessonsByChapterId(ChapterId);
            Console.WriteLine($"Found {lessons.Count} lessons");

            var layout = Content.FindByName<StackLayout>("ButtonStackLayout");
            layout.Children.Clear();
            var colorSecondary = (Color)Application.Current.Resources["Secondary"];
            var colorSecondaryDark = (Color)Application.Current.Resources["SecondaryDark"];

            foreach(var lesson in lessons.Where(l => l.Part == 1))
            {
                var button = new Button
                {
                    Text = $"Lesson {lesson.LessonNumber}: {lesson.Title}",
                    TextColor = Color.White
                };

                button.SetAppThemeColor(Button.BackgroundColorProperty, colorSecondary, colorSecondaryDark);
                button.Clicked += async (sender, args) =>
                {
                    Console.WriteLine($"Clicked {lesson.Title}");
                };
                layout.Children.Add(button);
            }
        }
    }
}