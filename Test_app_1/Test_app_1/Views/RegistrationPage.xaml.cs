using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_app_1.Services.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_app_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        private readonly IRestClient _restClient;

        public RegistrationPage()
        {
            _restClient = DependencyService.Get<IRestClient>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var username = Username_entry.Text;
            var email = Email_entry.Text;
            var password = Password_entry.Text;
            var confirm_password = Confirm_Password_entry.Text;

            if (!ValidateUsername(username))
            {
                await DisplayAlert("Username is wrong", "Username cannot be empty.", "OK");
                return;
            }

            if (!ValidateEmail(email))
            {
                await DisplayAlert("Email address is wrong", "Email address is not a valid address.", "OK");
                return;
            }

            if (!ValidatePassword(password, confirm_password))
            {
                await DisplayAlert("Confrim password does't match", "Make sure passwords are the same", "OK");
                return;
            }

            var result = await _restClient.RegisterUser(username, email, password);

            if (result.IsSuccessfull)
            {
                DependencyService.Get<IToastService>()?.MakeToast($"Successfully registered user {username}.");
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                DependencyService.Get<IToastService>()?.MakeToast($"Failed to register a user. Reason: {result.Message}");
            }
        }

        private bool ValidateEmail(string email)
        {
            var emailChecker = new EmailAddressAttribute();
            return !string.IsNullOrEmpty(email) && emailChecker.IsValid(email);
        }

        private bool ValidatePassword(string password, string confirmPassword)
        {
            return !string.IsNullOrEmpty(password) && password.Equals(confirmPassword);
        }

        private bool ValidateUsername(string username)
        {
            return !string.IsNullOrEmpty(username);
        }
    }
}