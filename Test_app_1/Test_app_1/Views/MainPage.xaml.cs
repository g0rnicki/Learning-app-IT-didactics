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
    public partial class MainPage : ContentPage
    {
        private readonly IRestClient _restClient;
        public MainPage()
        {
            _restClient = DependencyService.Get<IRestClient>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var totalLessonsFinished = await _restClient.GetTotalLessonsFinished(_restClient.GetCurrentUserId());

            var greeting = Content.FindByName<Label>("Greeting");
            var stat1 = Content.FindByName<Label>("Statistic1");
            var stat2 = Content.FindByName<Label>("Statistic2");
            var stat3 = Content.FindByName<Label>("Statistic3");

            var username = _restClient.GetCurrentUsername();

            greeting.Text = $"Welcome {username}";

            if (totalLessonsFinished.HasValue)
            {
                stat1.Text = $"Number of finished lessons: {totalLessonsFinished.Value}";
            }
        }
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}