using System;
using Test_app_1.Services;
using Test_app_1.Services.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_app_1
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            RegisterServices();

            MainPage = new AppShell();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void RegisterServices()
        {
            DependencyService.Register<IRestClient, RestClient>();
        }
    }
}
