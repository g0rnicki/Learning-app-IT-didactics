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
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var currentLesson = await _restClient.GetLessonById(LessonId);

            // TUTEJ UZUPEŁNIĆ DANYMI Z currentLesson
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(Question)}");
        }
    }
}