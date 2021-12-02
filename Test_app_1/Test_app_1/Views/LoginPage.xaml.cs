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
    public partial class LoginPage : ContentPage
    {
        private bool isLoggedIn;
        private readonly IRestClient _restClient;

        public LoginPage()
        {
            isLoggedIn = false;
            _restClient = DependencyService.Get<IRestClient>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (isLoggedIn) {
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var username = Username_entry.Text;
            var password = Password_entry.Text;
            var result = await _restClient.AuthorizeUser(username, password);
            Console.WriteLine(username + " " + password);
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }
    }
}