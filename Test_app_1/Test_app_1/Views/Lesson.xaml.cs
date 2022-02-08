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
            var content = Content.FindByName<Label>("Content");
            var button = Content.FindByName<Button>("Button");

            title.Text = currentLesson.Title;
            content.Text = currentLesson.Content;
            button.Clicked += async (sender, args) =>
            {
                await Shell.Current.GoToAsync($"{nameof(Question)}?CurrentLessonId={currentLesson.Id}");
                Console.WriteLine($"Transferred Id: {currentLesson.Id}");
            };

        }


    }
}