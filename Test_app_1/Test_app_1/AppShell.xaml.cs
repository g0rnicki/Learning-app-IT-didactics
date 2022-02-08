using System;
using System.Collections.Generic;
using Test_app_1.Views;
using Xamarin.Forms;

namespace Test_app_1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegistrationPage),
             typeof(RegistrationPage));

            Routing.RegisterRoute(nameof(LessonsPage),
             typeof(LessonsPage));

            Routing.RegisterRoute(nameof(Lesson),
             typeof(Lesson));

            Routing.RegisterRoute(nameof(Question),
             typeof(Question));
        }

    }
}
