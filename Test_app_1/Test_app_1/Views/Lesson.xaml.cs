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
    [QueryProperty(nameof(LessonId), nameof(LessonId))]
    public partial class Lesson : ContentPage
    {
        public int LessonId { get; set; }

        private readonly IRestClient _restClient;

        public Lesson()
        {
            _restClient = DependencyService.Get<IRestClient>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var currentLesson = await _restClient.GetLessonById(LessonId);
            var title = Content.FindByName<Label>("Title");
            var contentStackLayout = Content.FindByName<StackLayout>("ContentStackLayout");

            contentStackLayout.Children.Clear();

            string[] separator = { "\\n" };

            foreach(var cont in currentLesson.Content.Split(separator, StringSplitOptions.RemoveEmptyEntries))
            {
                var label = new Label
                {
                    Text = cont,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
                contentStackLayout.Children.Add(label);
            }

            var button = Content.FindByName<Button>("Button");

            title.Text = currentLesson.Title;
            button.Clicked += async (sender, args) =>
            {
                await Shell.Current.GoToAsync($"{nameof(Question)}?QuestionId={currentLesson.QuestionId}&LessonTitle={currentLesson.Title}");
                Console.WriteLine($"Transferred Id: {currentLesson.Id}");
            };

        }


    }
}