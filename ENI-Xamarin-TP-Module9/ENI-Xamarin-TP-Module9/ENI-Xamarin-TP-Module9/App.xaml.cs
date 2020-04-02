using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ENI_Xamarin_TP_Module9.Services;
using ENI_Xamarin_TP_Module9.Views;

namespace ENI_Xamarin_TP_Module9
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //MainPage = new MainPage();

            NavigationPage main = new NavigationPage(new MainPage());
            MainPage = main;
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
