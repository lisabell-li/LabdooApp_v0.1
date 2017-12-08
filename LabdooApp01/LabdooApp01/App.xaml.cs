using LabdooApp01.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LabdooApp01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new StartPage())
                    {
                        Title = "Start",
                        Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new DootripPage())
                    {
                        Title = "Dootrips",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                  
                    new NavigationPage(new DootronicsPage())
                    {
                        Title = "Dootronics",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                    new NavigationPage(new NewsPage())
                    {
                        Title = "News",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }
    }
}
