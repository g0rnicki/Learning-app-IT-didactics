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
    public partial class Lesson : ContentPage
    {
        public Lesson()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var layout = Content.FindByName<StackLayout>("LessonLayout");
            layout.Children.Clear();
            var colorSecondary = (Color)Application.Current.Resources["Secondary"];
            var colorSecondaryDark = (Color)Application.Current.Resources["SecondaryDark"];
           
        
            
            //Button button1 = new Button
            //{
            //    Text = "Button1",
            //    TextColor = Color.White,
            //};
            //button1.SetAppThemeColor(Button.BackgroundColorProperty, colorSecondary, colorSecondaryDark);

            //Button button2 = new Button
            //{
            //    Text = "Button1",
            //    TextColor = Color.White,
            //};
            //button1.SetAppThemeColor(Button.BackgroundColorProperty, colorSecondary, colorSecondaryDark);

            //Button button3 = new Button
            //{
            //    Text = "Button1",
            //    TextColor = Color.White,
            //};
            //button1.SetAppThemeColor(Button.BackgroundColorProperty, colorSecondary, colorSecondaryDark);

            //Button button4 = new Button
            //{
            //    Text = "Button1",
            //    TextColor = Color.White,
            //};
            //button1.SetAppThemeColor(Button.BackgroundColorProperty, colorSecondary, colorSecondaryDark);
        }
    }
}