using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace MasterBurgerDetail
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = GetMainPage();


        }
        static MasterDetailPage MDPage;

        public static Page GetMainPage()
        {
            MDPage = new MasterDetailPage
            {
                Master = new ContentPage
                {
                    Title = "Master",
                    Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null,
                    Content = new StackLayout
                    {
                        Children = { MenuLink("A"), MenuLink("B"), MenuLink("C") }
                    },
                },
                Detail = new NavigationPage(CreateContentPage("A")),
            };
            MDPage.IsPresentedChanged += (sender, e) => Debug.WriteLine(DateTime.Now + ": " + MDPage.IsPresented);
            return MDPage;
        }

        static Button MenuLink(string name)
        {
            return new Button
            {
                Text = name,
                Command = new Command(o => {
                    MDPage.Detail = new NavigationPage(CreateContentPage(name));
                    MDPage.IsPresented = false;
                }),
            };
        }

        static Button Link(string name)
        {
            return new Button
            {
                Text = name,
                Command = new Command(o => MDPage.Detail.Navigation.PushAsync(CreateContentPage(name))),
            };
        }

        static ContentPage CreateContentPage(string text)
        {
            return new ContentPage { Title = text, Content = Link(text + ".sub") };
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
