﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_app_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ChapterId), nameof(ChapterId))]
    public partial class LessonsPage : ContentPage
    {
        public int ChapterId { get; set; }

        public LessonsPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(LessonsPage)}");
        }

        protected override async void OnAppearing()
        {
            Console.WriteLine($"{ChapterId}");
        }
    }
}