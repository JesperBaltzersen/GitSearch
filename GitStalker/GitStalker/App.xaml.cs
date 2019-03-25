using System;
using GitStalker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GitStalker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SearchPage()) { BarBackgroundColor = (Color) Application.Current.Resources["barColor"], BarTextColor = (Color) Application.Current.Resources["textColor"]};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
