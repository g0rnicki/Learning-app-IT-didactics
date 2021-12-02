using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_app_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var username = Username_entry.Text;
            var email = Email_entry.Text;
            var password = Password_entry.Text;
            var confirm_password = Confirm_Password_entry.Text;

            if(password== confirm_password)
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            else
                await DisplayAlert("Confrim password does't match", "Make sure passwords are the same", "OK");

        }
    }
}