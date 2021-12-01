﻿using System;
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
            try
            {
                var result = await _restClient.AuthorizeUser("tomek", "huehue");
                Console.WriteLine(result.Token);
                if (result.IsSuccessfull)
                {
                    await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Button_Clicked Exception: {ex.Message}");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }
    }
}