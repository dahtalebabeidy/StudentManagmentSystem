using StudentManagmentSystem.Views;
using StudentManagmentSystem.Views.Student;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentManagmentSystem
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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
    }
}
