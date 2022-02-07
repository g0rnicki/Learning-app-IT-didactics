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
    public partial class ChaptersPage : ContentPage
    {
        private readonly IRestClient _restClient;

        public ChaptersPage()
        {
            _restClient = DependencyService.Get<IRestClient>(DependencyFetchTarget.GlobalInstance);
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(LessonsPage)}");
        }

        protected override async void OnAppearing()
        {
            var chapters = await _restClient.GetAllChapters();
            var layout = Content.FindByName<StackLayout>("ButtonStackLayout");
            var colorSecondary = (Color)Application.Current.Resources["Secondary"];
            var colorSecondaryDark = (Color)Application.Current.Resources["SecondaryDark"];

            foreach (var Chapter in chapters) 
            {
                Button button = new Button
                {
                    Text = Chapter.Name,
                    TextColor = Color.White,
            };
                button.SetAppThemeColor(Button.BackgroundColorProperty, colorSecondary , colorSecondaryDark );
                button.Clicked += async (sender, args) => await Shell.Current.GoToAsync($"{nameof(LessonsPage)}");

                layout.Children.Add(button);
            }

            Content = layout;
        }
    }
}