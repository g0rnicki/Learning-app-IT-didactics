using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_app_1.Services.Interfaces;
using Test_app_1.Services.Interfaces.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_app_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChaptersPage : ContentPage
    {
        private readonly IRestClient _restClient;
        private IList<ChapterDto> _chapters;

        public ChaptersPage()
        {
            _restClient = DependencyService.Get<IRestClient>(DependencyFetchTarget.GlobalInstance);
            _chapters = new List<ChapterDto>();
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(LessonsPage)}");
        }

        protected override async void OnAppearing()
        {
            _chapters = await _restClient.GetAllChapters();
            var layout = Content.FindByName<StackLayout>("ButtonStackLayout");
            layout.Children.Clear();
            var colorSecondary = (Color)Application.Current.Resources["Secondary"];
            var colorSecondaryDark = (Color)Application.Current.Resources["SecondaryDark"];

            foreach (var chapter in _chapters) 
            {
                Button button = new Button
                {
                    Text = chapter.Name,
                    TextColor = Color.White,
                };
                button.SetAppThemeColor(Button.BackgroundColorProperty, colorSecondary , colorSecondaryDark );
                button.Clicked += async (sender, args) =>
                {
                    if (chapter.Available)
                    {
                        await Shell.Current.GoToAsync($"{nameof(LessonsPage)}?ChapterId={chapter.Id}");
                    }
                    else
                    {
                        DependencyService.Get<IToastService>()?.MakeToast($"New chapters comming soon.");
                    }
                };
                layout.Children.Add(button);
            }

            //Content = layout;
        }
    }
}